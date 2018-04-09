using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Core.Runtime.Activities;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Mobioos.Foundation.Prompts;
using Mobioos.Scaffold.Core.Messaging.Events;
using Mobioos.Scaffold.Utils;

namespace Mobioos.Generators.AspNetCore
{
    [Activity(Order = 3)]
    public class ApiActivity : GeneratorActivity
    {
        string _sessionId;
        Dictionary<string, string> _serviceTypes;

        public ApiActivity(string name, string basePath) : base(name, basePath)
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
                var manifest = Context.DynamicContext.Manifest;

                if (!Directory.Exists(BasePath))
                    Directory.CreateDirectory(BasePath);

                TransformControllerApi(manifest);
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

        private void TransformControllerApi(SmartAppInfo manifest)
        {
            bool result = true;
            var apiList = manifest.Api.AsEnumerable();

            if (apiList != null)
            {
                foreach (var api in apiList)
                {
                    if (!result)
                        break;

                    if (api != null)
                    {
                        _serviceTypes = new Dictionary<string, string>();

                        foreach (var action in api.Actions)
                        {
                            TransformControllerApiReturnTypes(manifest, action);
                            TransformControllerApiParameters(manifest, action);
                        }

                        var template = new ApiController(api, manifest.Id, Constants.Version, _serviceTypes);
                        try
                        {
                            result = WriteFile(Path.Combine(BasePath, template.OutputPath, Constants.Version, api.Id + ".g.cs"), template.TransformText());
                        }
                        catch (Exception ex)
                        {
                            result = false;
                            Context.RuntimeContext.Runtime.Logger.Error($"error on generating controllers api for session: {_sessionId} with exception message: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void TransformControllerApiParameters(SmartAppInfo manifest, ApiActionInfo action)
        {
            bool result = true;

            foreach (var param in action.Parameters.AsEnumerable())
            {
                if (!result)
                    break;

                Dictionary<string, string> entityTypes = GetAllReferencedTypes(param);

                if (param.DataModel != null)
                {
                    var dataTemplate = new ViewModelTemplate(param.DataModel, manifest.Id, Constants.ViewModelNamespace, entityTypes);
                    try
                    {
                        result = WriteFile(Path.Combine(BasePath, dataTemplate.OutputPath, param.DataModel.Id + ".g.cs"), dataTemplate.TransformText());
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        Context.RuntimeContext.Runtime.Logger.Error($"error on generating controllers api parameters for session: {_sessionId} with exception message: {ex.Message}");
                    }
                }
            }
        }

        private void TransformControllerApiReturnTypes(SmartAppInfo manifest, ApiActionInfo action)
        {
            if (action.ReturnType != null)
            {
                Dictionary<string, string> entityTypes = GetAllReferencedTypes(action.ReturnType);

                var dataTemplate = new ViewModelTemplate(action.ReturnType, manifest.Id, Constants.ViewModelNamespace, entityTypes);

                try
                {
                    WriteFile(Path.Combine(BasePath, dataTemplate.OutputPath, action.ReturnType.Id + ".g.cs"), dataTemplate.TransformText());
                }
                catch (Exception ex)
                {
                    Context.RuntimeContext.Runtime.Logger.Error($"error on generating controllers api return types for session: {_sessionId} with exception message: {ex.Message}");
                }
            }
        }

        private Dictionary<string, string> GetAllReferencedTypes(ApiParameterInfo param)
        {
            Dictionary<string, string> entityTypes = GetAllReferencedTypes(param.DataModel);

            var type = GetTypeFromProperty(param.ModelProperty);

            if (!entityTypes.ContainsKey(type) && !string.IsNullOrEmpty(type))
                entityTypes.Add(type, param.Id);
            if (!_serviceTypes.ContainsKey(type) && !string.IsNullOrEmpty(type))
                _serviceTypes.Add(type, param.Id);

            return entityTypes;
        }

        private Dictionary<string, string> GetAllReferencedTypes(EntityInfo entity)
        {
            var entityTypes = new Dictionary<string, string>();
            if (entity != null)
            {
                foreach (var property in entity.Properties.AsEnumerable())
                {
                    var subType = GetTypeFromProperty(property.ModelProperty);
                    if (!entityTypes.ContainsKey(subType) && !string.IsNullOrEmpty(subType))
                        entityTypes.Add(subType, property.Id);
                    if (!_serviceTypes.ContainsKey(subType) && !string.IsNullOrEmpty(subType))
                        _serviceTypes.Add(subType, property.Id);
                }

                foreach (var property in entity.References.AsEnumerable())
                {
                    if (!entityTypes.ContainsKey(property.Type) && !string.IsNullOrEmpty(property.Id))
                        entityTypes.Add(property.Type, property.Id);
                    if (!_serviceTypes.ContainsKey(property.Type) && !string.IsNullOrEmpty(property.Id))
                        _serviceTypes.Add(property.Type, property.Id);
                }
            }

            return entityTypes;
        }

        private string GetTypeFromProperty(string property)
        {
            if (!string.IsNullOrEmpty(property))
            {
                int index = property.IndexOf('.');
                if (index > 0)
                {
                    return property.Substring(0, index);
                }
            }

            return string.Empty;
        }

        protected void HandleErrors(string sessionId)
        {
            Notify(new NotificationMessage { ActivityName = this.Name, Message = RuntimeHelper.GetLogUrl(Context.DynamicContext.ServerUrl, Context.RuntimeContext.Runtime.ChannelId.ToString()), Type = Foundation.Prompts.Interfaces.NotificationTypes.BootstrapFailed }, this);
            Publish(new TaskError());
        }
    }
}
