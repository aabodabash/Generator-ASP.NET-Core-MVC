using Mobioos.Scaffold.Core.Runtime.Activities;
using System.Reflection;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System.IO;
using Mobioos.Foundation.Jade.Models;
using System;
using System.Linq;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Extensions;
using Mobioos.Scaffold.Core.Exceptions;
using Mobioos.Foundation.Prompts;
using Mobioos.Scaffold.Core.Messaging.Events;
using Mobioos.Scaffold.Utils;

namespace Mobioos.Generators.AspNetCore
{
    [Activity(Order = 2)]
    public class DataActivity : GeneratorActivity
    {
        string _sessionId;

        public DataActivity(string name, string basePath) : base(name, basePath)
        {
        }

        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            _sessionId = activityContext.RuntimeContext.Runtime.SessionId.ToString();

            await base.Initializing(activityContext);
        }

        [Task(Order = 2)]
        public async override Task Writing()
        {
            bool hasError = false;

            if (null == Context.DynamicContext.Manifest)
                throw new NullReferenceException("Manifest object is null or empty");

            var sessionId = Context.RuntimeContext.Runtime.SessionId.ToString();

            try
            {
                CheckPrimaryKeys();

                var manifest = Context.DynamicContext.Manifest;

                if (ExecuteTemplates(nameof(DataActivity), BasePath, manifest, Assembly.GetExecutingAssembly()))
                {
                    if (!Directory.Exists(BasePath))
                        Directory.CreateDirectory(BasePath);

                    TransformDataModels(manifest);
                    TransformControllers(manifest);
                    TransformViews(manifest);
                }
            }
            catch (Exception e)
            {
                hasError = true;
                Context.RuntimeContext.Runtime.Logger.Error($"exception occured on data activity for session: {sessionId}, exception message: {e.Message}");
                HandleErrors(sessionId);
            }

            if (!hasError)
            {
                await base.Writing();
            }
        }

        private void TransformDataModels(SmartAppInfo manifest)
        {
            TransformEntities(manifest);
            TransformEnums(manifest);
        }

        private void TransformEntities(SmartAppInfo manifest)
        {
            try
            {
                var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsEnum).AsEnumerable();
                foreach (var entity in enabledEntities)
                {
                    Context.RuntimeContext.Runtime.Logger.Info($"generating entity: {entity.Id}");

                    var template = new DataModelTemplate(entity, manifest.Id, Constants.DataNamespace);
                    WriteFile(Path.Combine(BasePath, template.OutputPath, $"{entity.Id}.g.cs"), template.TransformText());

                    if (!entity.IsAbstract)
                    {
                        var key = entity.AllProperties()?.FirstOrDefault(p => p.IsKey);
                        if (key == null)
                        {
                            Context.RuntimeContext.Runtime.Logger.Warn($"Entity: {entity.Id} does not contain a primary key");
                        }
                        else
                        {
                            var irepositoryTemplate = new IDataRepository(entity, manifest.Id, Constants.Version);
                            WriteFile(Path.Combine(BasePath, irepositoryTemplate.OutputPath, $"I{entity.Id}Repository.g.cs"), irepositoryTemplate.TransformText());

                            var repositoryTemplate = new DataRepository(entity, manifest.Id, Constants.Version);
                            WriteFile(Path.Combine(BasePath, repositoryTemplate.OutputPath, $"{entity.Id}Repository.g.cs"), repositoryTemplate.TransformText());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Context.RuntimeContext.Runtime.Logger.Error($"error on generating application data model for session: {_sessionId} with exception message: {ex.Message}");
                Context.RuntimeContext.Runtime.Logger.Error($"Stacktrace: {ex.StackTrace}");
            }
        }

        private void TransformEnums(SmartAppInfo manifest)
        {
            try
            {
                var enums = manifest.DataModel.Entities.Where(e => e.IsEnum).AsEnumerable();
                foreach (var model in enums)
                {
                    var template = new EnumTemplate(model, manifest.Id, Constants.DataNamespace);
                    WriteFile(Path.Combine(BasePath, template.OutputPath, $"{model.Id}.g.cs"), template.TransformText());

                }
            }
            catch (Exception ex)
            {
                Context.RuntimeContext.Runtime.Logger.Error($"error on generating enums for session: {_sessionId} with exception message: {ex.Message}");
            }
        }

        private void TransformControllers(SmartAppInfo manifest)
        {
            TransformServiceInterfaces(manifest);
            TransformServices(manifest);
            //TransformControllerEntities(manifest);
        }

        private void TransformControllerEntities(SmartAppInfo manifest)
        {
            var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract && !e.IsEnum);
            foreach (var entity in enabledEntities)
            {
                var key = entity.AllProperties()?.FirstOrDefault(p => p.IsKey);
                if (key == null)
                {
                    Context.RuntimeContext.Runtime.Logger.Warn($"Entity: {entity.Id} does not contain a primary key");
                }
                else
                {
                    var entityTemplate = new EntityApiController(entity, manifest.Id, Constants.Version);
                    WriteFile(Path.Combine(BasePath, entityTemplate.OutputPath, Constants.Version, entity.Id + "Controller.g.cs"), entityTemplate.TransformText());

                    var mvcTemplate = new EntityMvcController(entity, manifest.Id);
                    WriteFile(Path.Combine(BasePath, mvcTemplate.OutputPath, entity.Id + "Controller.g.cs"), mvcTemplate.TransformText());
                }
            }
        }

        private void TransformServiceInterfaces(SmartAppInfo manifest)
        {
            try
            {
                var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract && e.AllProperties().FirstOrDefault(p => p.IsKey) != null);
                foreach (var entity in enabledEntities)
                {
                    var template = new IServiceTemplate(entity, manifest.Id, Constants.Version);

                    WriteFile(Path.Combine(BasePath, template.OutputPath, $"I{entity.Id}Service.g.cs"), template.TransformText());
                }
            }
            catch (Exception ex)
            {
                Context.RuntimeContext.Runtime.Logger.Error($"error on generating data services interfaces for session: {_sessionId} with exception message: {ex.Message}");
            }
        }

        private void TransformServices(SmartAppInfo manifest)
        {
            bool result = true;
            try
            {
                var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract && e.AllProperties().FirstOrDefault(p => p.IsKey) != null);
                foreach (var entity in enabledEntities)
                {
                    if (!result)
                        break;

                    try
                    {
                        var template = new ServiceTemplate(entity, manifest.Id, Constants.Version);
                        result = WriteFile(Path.Combine(BasePath, template.OutputPath, $"{entity.Id}Service.g.cs"), template.TransformText());
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        Context.RuntimeContext.Runtime.Logger.Error($"error on generating entity {entity.Id} for session: {_sessionId} with exception message: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Context.RuntimeContext.Runtime.Logger.Error($"error on generating data services for session: {_sessionId} with exception message: {ex.Message}");
            }
        }

        private void TransformViews(SmartAppInfo manifest)
        {
            var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract);
            foreach (var entity in enabledEntities)
            {
                var applicationId = manifest.Id;

                var createTemplate = new CreateTemplate(entity, applicationId);
                var editTemplate = new EditTemplate(entity, applicationId);
                var detailTemplate = new DetailsTemplate(entity, applicationId);
                var deleteTemplate = new DeleteTemplate(entity, applicationId);
                var indexTemplate = new IndexTemplate(entity, applicationId);

                WriteFile(Path.Combine(BasePath, createTemplate.OutputPath, entity.Id, "Create.cshtml"), createTemplate.TransformText());
                WriteFile(Path.Combine(BasePath, editTemplate.OutputPath, entity.Id, "Edit.cshtml"), editTemplate.TransformText());
                WriteFile(Path.Combine(BasePath, deleteTemplate.OutputPath, entity.Id, "Delete.cshtml"), deleteTemplate.TransformText());
                WriteFile(Path.Combine(BasePath, detailTemplate.OutputPath, entity.Id, "Details.cshtml"), detailTemplate.TransformText());
                WriteFile(Path.Combine(BasePath, indexTemplate.OutputPath, entity.Id, "Index.cshtml"), indexTemplate.TransformText());
            }
        }

        private void CheckPrimaryKeys()
        {
            var manifest = Context.DynamicContext.Manifest as SmartAppInfo;
            var entitiesWithoutPrimaryKey = manifest.DataModel.Entities.Where(e => !e.IsAbstract && !e.IsEnum && e.AllProperties().FirstOrDefault(p => p.IsKey) == null);
            if (entitiesWithoutPrimaryKey != null && entitiesWithoutPrimaryKey.Count() > 0)
            {
                foreach (var entity in entitiesWithoutPrimaryKey)
                {
                    Context.RuntimeContext.Runtime.Logger.Error($"Entity {entity.Id} is declared without a primary key");
                }

                throw new TaskFailedException($"{nameof(DataActivity)}: One or more entities do not define a primary key");
            }
        }

        protected void HandleErrors(string sessionId)
        {
            Notify(new NotificationMessage { ActivityName = this.Name, Message = RuntimeHelper.GetLogUrl(Context.DynamicContext.ServerUrl, Context.RuntimeContext.Runtime.ChannelId.ToString()), Type = Foundation.Prompts.Interfaces.NotificationTypes.BootstrapFailed }, this);
            Publish(new TaskError());
        }
    }
}
