using Mobioos.Foundation.Jade.Models;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private IDictionary<string, string> _serviceTypes;

        public ApiWritingStep(ISessionContext context, IWriting writingService, IWorkflowNotifier workflowNotifier)
        {
            _context = context;
            _writingService = writingService;
            _workflowNotifier = workflowNotifier;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new NullReferenceException("Manifest object is null or empty");

            var manifest = _context.Manifest;
            _workflowNotifier.Notify(nameof(ApiWritingStep), NotificationType.GeneralInfo, "Generating asp.net core apis");
            if (_context.BasePath != null)
            {
                if (!Directory.Exists(_context.BasePath))
                    Directory.CreateDirectory(_context.BasePath);

                TransformControllerApi(manifest);
            }

            return Task.FromResult(ExecutionResult.Next());
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
                            result = _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath, Constants.Version, api.Id + ".g.cs"), template.TransformText());
                        }
                        catch (Exception ex)
                        {
                            result = false;
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
                        result = _writingService.WriteFile(Path.Combine(_context.BasePath, dataTemplate.OutputPath, param.DataModel.Id + ".g.cs"), dataTemplate.TransformText());
                    }
                    catch (Exception ex)
                    {
                        result = false;
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
                _writingService.WriteFile(Path.Combine(_context.BasePath, dataTemplate.OutputPath, action.ReturnType.Id + ".g.cs"), dataTemplate.TransformText());
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
    }
}
