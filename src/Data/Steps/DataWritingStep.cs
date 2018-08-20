using Mobioos.Foundation.Jade.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
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

        public DataWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }
        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new NullReferenceException("Manifest object is null or empty");
            if (_context.BasePath != null)
            {
                if (!Directory.Exists(_context.BasePath))
                    Directory.CreateDirectory(_context.BasePath);

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
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformDataModels(SmartAppInfo manifest)
        {
            TransformEntities(manifest);
            TransformEnums(manifest);
        }

        private void TransformEntities(SmartAppInfo manifest)
        {
            var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsEnum).AsEnumerable();
            foreach (var entity in enabledEntities)
            {
                var template = new DataModelTemplate(entity, manifest.Id, Constants.DataNamespace);
                _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, $"{entity.Id}.g.cs"), template.TransformText());

                if (!entity.IsAbstract)
                {
                    var key = entity.AllProperties()?.FirstOrDefault(p => p.IsKey);
                    if (key != null)
                    {
                        var irepositoryTemplate = new IDataRepository(entity, manifest.Id, Constants.Version);
                        _writingService.WriteFile(Path.Combine(_context.BasePath, irepositoryTemplate.OutputPath, $"I{entity.Id}Repository.g.cs"), irepositoryTemplate.TransformText());

                        var repositoryTemplate = new DataRepository(entity, manifest.Id, Constants.Version);
                        _writingService.WriteFile(Path.Combine(_context.BasePath, repositoryTemplate.OutputPath, $"{entity.Id}Repository.g.cs"), repositoryTemplate.TransformText());
                    }
                }
            }
        }

        private void TransformEnums(SmartAppInfo manifest)
        {
            var enums = manifest.DataModel.Entities.Where(e => e.IsEnum).AsEnumerable();
            foreach (var model in enums)
            {
                var template = new EnumTemplate(model, manifest.Id, Constants.DataNamespace);
                _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, $"{model.Id}.g.cs"), template.TransformText());

            }
        }

        private void TransformControllers(SmartAppInfo manifest)
        {
            TransformServiceInterfaces(manifest);
            TransformServices(manifest);
        }

        private void TransformServiceInterfaces(SmartAppInfo manifest)
        {
            var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract && e.AllProperties().FirstOrDefault(p => p.IsKey) != null);
            foreach (var entity in enabledEntities)
            {
                var template = new IServiceTemplate(entity, manifest.Id, Constants.Version);
                _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, $"I{entity.Id}Service.g.cs"), template.TransformText());
            }
        }

        private void TransformServices(SmartAppInfo manifest)
        {
            bool result = true;
            var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsAbstract && e.AllProperties().FirstOrDefault(p => p.IsKey) != null);
            foreach (var entity in enabledEntities)
            {
                if (!result)
                    break;
                var template = new ServiceTemplate(entity, manifest.Id, Constants.Version);
                result = _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, $"{entity.Id}Service.g.cs"), template.TransformText());
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

                _writingService.WriteFile(Path.Combine(_context.BasePath, createTemplate.OutputPath, entity.Id, "Create.cshtml"), createTemplate.TransformText());
                _writingService.WriteFile(Path.Combine(_context.BasePath, editTemplate.OutputPath, entity.Id, "Edit.cshtml"), editTemplate.TransformText());
                _writingService.WriteFile(Path.Combine(_context.BasePath, deleteTemplate.OutputPath, entity.Id, "Delete.cshtml"), deleteTemplate.TransformText());
                _writingService.WriteFile(Path.Combine(_context.BasePath, detailTemplate.OutputPath, entity.Id, "Details.cshtml"), detailTemplate.TransformText());
                _writingService.WriteFile(Path.Combine(_context.BasePath, indexTemplate.OutputPath, entity.Id, "Index.cshtml"), indexTemplate.TransformText());
            }
        }
    }
}
