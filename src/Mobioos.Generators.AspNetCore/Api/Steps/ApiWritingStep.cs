using Common.Generator.Framework.Extensions;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore.Api.Steps
{
    public class ApiWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;
        private readonly IWorkflowNotifier _workflowNotifier;

        public ApiWritingStep(
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

            var manifest = _context.Manifest;

            _workflowNotifier.Notify(
                nameof(ApiWritingStep),
                NotificationType.GeneralInfo,
                "Generating asp.net core apis");

            if (_context.BasePath != null)
            {
                if (!Directory.Exists(_context.BasePath))
                {
                    Directory.CreateDirectory(_context.BasePath);
                }

                TransformControllerApi(manifest);
            }

            return Task.FromResult(ExecutionResult.Next());
        }


        private void TransformControllerApi(SmartAppInfo manifest)
        {
            foreach (var api in manifest.Api)
            {
                if (api.IsValid())
                {
                    foreach (var action in api.Actions)
                    {
                        if (action.IsValid())
                        {
                            TransformControllerApiParameters(
                                manifest,
                                action);
                        }
                    }

                    var viewModels = api.GetApiViewModelsEntities();

                    var serviceTypes = new List<string>();

                    foreach (var viewModel in viewModels)
                    {
                        var modelProperties = viewModel.ModelPropertiesTypes();

                        foreach (var modelProperty in modelProperties)
                        {
                            if (!serviceTypes.Contains(modelProperty.Key))
                            {
                                serviceTypes.Add(modelProperty.Key);
                            }
                        }
                    }

                    var template = new ApiController(
                        api,
                        manifest.Id,
                        Constants.Version,
                        serviceTypes);

                    _writingService.WriteFile(
                        Path.Combine(
                            _context.BasePath,
                            template.OutputPath,
                            $"{manifest.Id}{api.Id}.g.cs"),
                        template.TransformText());
                }
            }
        }

        private void TransformControllerApiParameters(
            SmartAppInfo manifest,
            ApiActionInfo action)
        {
            var viewModels = action.GetApiActionViewModelsEntities();

            foreach (var viewModel in viewModels)
            {
                var modelPropertiesTypes = viewModel.ModelPropertiesTypes();

                var dataTemplate = new ViewModelTemplate(
                    viewModel,
                    manifest.Id,
                    Constants.ViewModelNamespace,
                    modelPropertiesTypes);

                _writingService.WriteFile(
                    Path.Combine(
                        _context.BasePath,
                        dataTemplate.OutputPath,
                        $"{viewModel.Id.ToPascalCase()}.g.cs"),
                    dataTemplate.TransformText());
            }
        }
    }
}
