using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore.Security.Steps
{
    public class SecurityWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;

        public SecurityWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            var manifest = _context.Manifest;

            var roles = new List<string>();

            if (!Directory.Exists(_context.BasePath))
                Directory.CreateDirectory(_context.BasePath);

            TransformStartupAuth(manifest);
            TransformRoles(manifest, roles);
            TransformAll(manifest);
            return Task.FromResult(ExecutionResult.Next());
    }

        private void TransformAll(SmartAppInfo manifest)
        {
            TransformJwtIssuerOptions(manifest);
            TransformJwtFactory(manifest);
            TrasnformIJwtFactory(manifest);
            TransformFacebookAuthViewModel(manifest);
            TransformAuthSettings(manifest);
            TransformFacebookApiResponses(manifest);
            TransformExernalAuthController(manifest);
            TransformConstantsTemplate(manifest);
            TransformAuthController(manifest);
        }

        private void TransformJwtIssuerOptions(SmartAppInfo manifest)
        {
            var template = new JwtIssuerOptions(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformJwtFactory(SmartAppInfo manifest)
        {
            var template = new JwtFactory(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TrasnformIJwtFactory(SmartAppInfo manifest)
        {
            var template = new IJwtFactory(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformFacebookAuthViewModel(SmartAppInfo manifest)
        {
            var template = new FacebookAuthViewModel(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformAuthSettings(SmartAppInfo manifest)
        {
            var template = new AuthSettings(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformFacebookApiResponses(SmartAppInfo manifest)
        {
            var template = new FacebookApiResponses(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformExernalAuthController(SmartAppInfo manifest)
        {
            var template = new ExternalAuthController(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformConstantsTemplate(SmartAppInfo manifest)
        {
            var template = new ConstantsTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformAuthController(SmartAppInfo manifest)
        {
            var template = new AuthController(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformRoles(SmartAppInfo manifest, List<string> roles)
        {
            var template = new RolesTemplate(manifest, roles);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformStartupAuth(SmartAppInfo manifest)
        {
            var authenticationKeys = _context.DynamicContext.AuthenticationKeys as IDictionary<string, string>;
            var template = new StartupAuth(manifest, authenticationKeys);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }
    }
}
