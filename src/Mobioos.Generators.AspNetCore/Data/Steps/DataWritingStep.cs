using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore.Data.Steps
{
    public class DataWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public DataWritingStep(
            ISessionContext context,
            IWriting writingService,
            IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (_context.Manifest == null)
            {
                throw new NullReferenceException("Manifest object is null or empty");
            }

            _workflowNotifier.Notify(
                nameof(DataWritingStep),
                NotificationType.GeneralInfo,
                "Generating asp.net core models");

            if (_context.BasePath != null)
            {
                if (!Directory.Exists(_context.BasePath))
                {
                    Directory.CreateDirectory(_context.BasePath);
                }

                TransformDbContext(_context.Manifest);
                TransformDataModels(_context.Manifest);
                TransformControllers(_context.Manifest);
                TransformViews(_context.Manifest);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformDbContext(SmartAppInfo manifest)
        {
            var template = new DbContext(manifest);

            _writingService.WriteFile(
                Path.Combine(
                    _context.BasePath,
                    template.OutputPath),
                template.TransformText());
        }

        private void TransformDataModels(SmartAppInfo manifest)
        {
            TransformEntities(manifest);
            TransformEnums(manifest);
        }

        private void TransformEntities(SmartAppInfo manifest)
        {
            var enabledEntities = manifest
                .GetModels()
                .Where(e => !e.IsEnum);

            foreach (var entity in enabledEntities)
            {
                var template = new DataModelTemplate(
                    entity,
                    manifest.Id,
                    Constants.DataNamespace);

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        template.OutputPath,
                        $"{entity.Id}.g.cs"),
                    template.TransformText());

                if (!entity.IsAbstract)
                {
                    var key = entity
                        .GetProperties()?
                        .FirstOrDefault(p => p.IsKey);

                    if (key != null)
                    {
                        var irepositoryTemplate = new IDataRepository(
                            entity,
                            manifest.Id,
                            Constants.Version);

                        _writingService.WriteFile(
                            Path.Combine(
                                _context.BasePath,
                                irepositoryTemplate.OutputPath,
                                $"I{entity.Id}Repository.g.cs"),
                            irepositoryTemplate.TransformText());

                        var repositoryTemplate = new DataRepository(
                            entity,
                            manifest.Id,
                            Constants.Version);

                        _writingService.WriteFile(
                            Path.Combine(
                                _context.BasePath,
                                repositoryTemplate.OutputPath,
                                $"{entity.Id}Repository.g.cs"),
                            repositoryTemplate.TransformText());
                    }
                }
            }
        }

        private void TransformEnums(SmartAppInfo manifest)
        {
            var enums = manifest
                .GetModels()
                .Where(e => e.IsEnum);

            foreach (var model in enums)
            {
                var template = new EnumTemplate(
                    model,
                    manifest.Id,
                    Constants.DataNamespace);

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        template.OutputPath,
                        $"{model.Id}.g.cs"),
                    template.TransformText());

            }
        }

        private void TransformControllers(SmartAppInfo manifest)
        {
            TransformServiceInterfaces(manifest);
            TransformServices(manifest);
        }

        private void TransformServiceInterfaces(SmartAppInfo manifest)
        {
            var models = manifest.GetModels();

            var enabledEntities = models
                .Where(e =>
                    !e.IsAbstract
                    && e.GetProperties()
                        .FirstOrDefault(p => p.IsKey) != null
                    && !e.IsInherited(models));

            foreach (var entity in enabledEntities)
            {
                var template = new IServiceTemplate(
                    entity,
                    manifest.Id,
                    Constants.Version);

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        template.OutputPath,
                        $"I{entity.Id}Service.g.cs"),
                    template.TransformText());
            }
        }

        private void TransformServices(SmartAppInfo manifest)
        {
            var models = manifest.GetModels();
            var enabledEntities = models
                .Where(e =>
                    !e.IsAbstract
                    && e.GetProperties()
                        .FirstOrDefault(p => p.IsKey) != null
                    && !e.IsInherited(models));

            foreach (var entity in enabledEntities)
            {
                var template = new ServiceTemplate(
                    entity,
                    manifest.Id,
                    Constants.Version);

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        template.OutputPath,
                        $"{entity.Id}Service.g.cs"),
                    template.TransformText());
            }
        }

        private void TransformViews(SmartAppInfo manifest)
        {
            var models = manifest.GetModels();

            var enabledEntities = models
                .Where(e =>
                    !e.IsAbstract
                    && e.GetProperties()
                        .FirstOrDefault(p => p.IsKey) != null
                    && !e.IsInherited(models));

            foreach (var entity in enabledEntities)
            {
                var applicationId = manifest.Id;

                var createTemplate = new CreateTemplate(
                    entity,
                    applicationId);

                var editTemplate = new EditTemplate(
                    entity,
                    applicationId);

                var detailTemplate = new DetailsTemplate(
                    entity,
                    applicationId);

                var deleteTemplate = new DeleteTemplate(
                    entity,
                    applicationId);

                var indexTemplate = new IndexTemplate(
                    entity,
                    applicationId);

                var entityId = entity.Id.ToPascalCase();

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        createTemplate.OutputPath,
                        entityId,
                        "Create.cshtml"),
                    createTemplate.TransformText());

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        editTemplate.OutputPath,
                        entityId,
                        "Edit.cshtml"),
                    editTemplate.TransformText());

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        deleteTemplate.OutputPath,
                        entityId,
                        "Delete.cshtml"),
                    deleteTemplate.TransformText());

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        detailTemplate.OutputPath,
                        entityId,
                        "Details.cshtml"),
                    detailTemplate.TransformText());

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        indexTemplate.OutputPath,
                        entityId,
                        "Index.cshtml"),
                    indexTemplate.TransformText());
            }
        }
    }
}
