using Foundation.Prompt;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore.Common.Steps
{
    public class CommonWritingStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IWriting _writingService;

        public CommonWritingStep(ISessionContext context, IWriting writingService)
        {
            _context = context;
            _writingService = writingService;
        }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (null == _context.Manifest)
                throw new ArgumentNullException(nameof(_context.Manifest));

            if (_context.BasePath != null && _context.GeneratorPath != null)
            {
                var facebookAuthConsumerKey = (((IDictionary<string, object>)_context.DynamicContext).ContainsKey("FacebookAuthConsumerKey")) ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["FacebookAuthConsumerKey"]).First().Value : null;
                var facebookAuthConsumerSecret = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("FacebookAuthConsumerSecret") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["FacebookAuthConsumerSecret"]).First().Value : null;
                var twitterAuthAppId = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("TwitterAuthAppId") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["TwitterAuthAppId"]).First().Value : null;
                var twitterAuthAppSecret = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("TwitterAuthAppSecret") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["TwitterAuthAppSecret"]).First().Value : null;
                var googleAuthClientId = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("GoogleAuthClientId") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["GoogleAuthClientId"]).First().Value : null;
                var googleAuthSecret = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("GoogleAuthSecret") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["GoogleAuthSecret"]).First().Value : null;
                var microsoftAuthClientId = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("MicrosoftAuthClientId") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["MicrosoftAuthClientId"]).First().Value : null;
                var microsoftAuthSecret = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("MicrosoftAuthSecret") ? ((List<Answer>)((IDictionary<string, object>)_context.DynamicContext)["MicrosoftAuthSecret"]).First().Value : null;

                var authentiationKeys = new Dictionary<string, string>();
                if (facebookAuthConsumerKey != null)
                    authentiationKeys.Add("FacebookAuthConsumerKey", facebookAuthConsumerKey);
                if (facebookAuthConsumerSecret != null)
                    authentiationKeys.Add("FacebookAuthConsumerSecret", facebookAuthConsumerSecret);
                if (twitterAuthAppId != null)
                    authentiationKeys.Add("TwitterAuthAppId", twitterAuthAppId);
                if (twitterAuthAppSecret != null)
                    authentiationKeys.Add("TwitterAuthAppSecret", twitterAuthAppSecret);
                if (googleAuthClientId != null)
                    authentiationKeys.Add("GoogleAuthClientId", googleAuthClientId);
                if (googleAuthSecret != null)
                    authentiationKeys.Add("GoogleAuthSecret", googleAuthSecret);
                if (microsoftAuthClientId != null)
                    authentiationKeys.Add("MicrosoftAuthClientId", microsoftAuthClientId);
                if (microsoftAuthSecret != null)
                    authentiationKeys.Add("MicrosoftAuthSecret", microsoftAuthSecret);
                _context.DynamicContext.AuthenticationKeys = authentiationKeys;

                var directoryPath = Path.Combine(_context.GeneratorPath, "Common\\Templates");
                TransformStartup(_context.Manifest);
                TransformProject(_context.Manifest);
                TransformProgramTemplate(_context.Manifest);
                TransformControllersAccountController(_context.Manifest);
                TransformControllersControllerBase(_context.Manifest);
                TransformControllersHomeController(_context.Manifest);
                TransformControllersManageController(_context.Manifest);
                TransformDataIRepositoryTemplate(_context.Manifest);
                TransformDataRepositoryTemplate(_context.Manifest);
                TransformModelsAccountViewModel(_context.Manifest);
                TransformModelsAdminViewModel(_context.Manifest);
                TransformModelsApplicationUser(_context.Manifest);
                TransformModelsManageViewModel(_context.Manifest);
                TransformServicesEmailSender(_context.Manifest);
                TransformServicesMessageServices(_context.Manifest);
                TransformServicesSmsSender(_context.Manifest);
                TransformViewsAccountAccessDenied(_context.Manifest);
                TransformViewsAccountConfirmEmail(_context.Manifest);
                TransformViewsAccountExternalLoginConfirmation(_context.Manifest);
                TransformViewsAccountExternalLoginFailure(_context.Manifest);
                TransformViewsAccountForgotPassword(_context.Manifest);
                TransformViewsAccountForgotPasswordConfirmation(_context.Manifest);
                TransformViewsAccountLockout(_context.Manifest);
                TransformViewsAccountLogin(_context.Manifest);
                TransformViewsAccountRegister(_context.Manifest);
                TransformViewsAccountResetPassword(_context.Manifest);
                TransformViewsAccountResetPasswordConfirmation(_context.Manifest);
                TransformViewsAccountSendCode(_context.Manifest);
                TransformViewsAccountVerifyCode(_context.Manifest);
                TransformViewsHomeHomeAbout(_context.Manifest);
                TransformViewsHomeHomeContact(_context.Manifest);
                TransformViewsHomeHomeDashboard(_context.Manifest);
                TransformViewsHomeHomeIndex(_context.Manifest);
                TransformViewsManageManageAddPhoneNumber(_context.Manifest);
                TransformViewsManageManageChangePassword(_context.Manifest);
                TransformViewsManageManageIndex(_context.Manifest);
                TransformViewsManageManageLogins(_context.Manifest);
                TransformViewsManageManageSetPassword(_context.Manifest);
                TransformViewsManageManageVerifyPhoneNumber(_context.Manifest);
                TransformViewsRoleAdminRoleCreate(_context.Manifest);
                TransformViewsRoleAdminRoleDelete(_context.Manifest);
                TransformViewsRoleAdminRoleDetails(_context.Manifest);
                TransformViewsRoleAdminRoleEdit(_context.Manifest);
                TransformViewsRoleAdminRoleIndex(_context.Manifest);
                TransformViewsSharedError(_context.Manifest);
                TransformViewsSharedLayoutTemplate(_context.Manifest);
                TransformViewsSharedLoginPartial(_context.Manifest);
                TransformViewsSharedValidationScriptsPartial(_context.Manifest);
                TransformViewsViewImports(_context.Manifest);
                TransformViewsViewStart(_context.Manifest);
                TransformHelpersErrorsTemplate(_context.Manifest);
                TransformHelpersTokensTemplate(_context.Manifest);
                TransformDesignTimeDbContextFactory(_context.Manifest);
                TransformAppSettings(_context.Manifest);

                _writingService.CopyDirectory(directoryPath, _context.BasePath);
            }

            return Task.FromResult(ExecutionResult.Next());
        }

        private void TransformDesignTimeDbContextFactory(SmartAppInfo manifest)
        {
            var template = new DesignTimeDbContextFactory(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformHelpersTokensTemplate(SmartAppInfo manifest)
        {
            var template = new TokensTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformHelpersErrorsTemplate(SmartAppInfo manifest)
        {
            var template = new ErrorsTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsViewStart(SmartAppInfo manifest)
        {
            var template = new ViewStart(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsViewImports(SmartAppInfo manifest)
        {
            var template = new ViewImports(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsSharedValidationScriptsPartial(SmartAppInfo manifest)
        {
            var template = new ValidationScriptsPartial(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsSharedLoginPartial(SmartAppInfo manifest)
        {
            var template = new LoginPartial(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsSharedLayoutTemplate(SmartAppInfo manifest)
        {
            var template = new LayoutTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsSharedError(SmartAppInfo manifest)
        {
            var template = new Error(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsRoleAdminRoleIndex(SmartAppInfo manifest)
        {
            var template = new RoleIndex(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsRoleAdminRoleEdit(SmartAppInfo manifest)
        {
            var template = new RoleEdit(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsRoleAdminRoleDetails(SmartAppInfo manifest)
        {
            var template = new RoleDetails(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsRoleAdminRoleDelete(SmartAppInfo manifest)
        {
            var template = new RoleDelete(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsRoleAdminRoleCreate(SmartAppInfo manifest)
        {
            var template = new RoleCreate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageVerifyPhoneNumber(SmartAppInfo manifest)
        {
            var template = new ManageVerifyPhoneNumber(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageSetPassword(SmartAppInfo manifest)
        {
            var template = new ManageSetPassword(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageLogins(SmartAppInfo manifest)
        {
            var template = new ManageLogins(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageIndex(SmartAppInfo manifest)
        {
            var template = new ManageIndex(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageChangePassword(SmartAppInfo manifest)
        {
            var template = new ManageChangePassword(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsManageManageAddPhoneNumber(SmartAppInfo manifest)
        {
            var template = new ManageAddPhoneNumber(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsHomeHomeIndex(SmartAppInfo manifest)
        {
            var template = new HomeIndex(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsHomeHomeDashboard(SmartAppInfo manifest)
        {
            var template = new HomeDashboard(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsHomeHomeContact(SmartAppInfo manifest)
        {
            var template = new HomeContact(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsHomeHomeAbout(SmartAppInfo manifest)
        {
            var template = new HomeAbout(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountVerifyCode(SmartAppInfo manifest)
        {
            var template = new VerifyCode(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountSendCode(SmartAppInfo manifest)
        {
            var template = new SendCode(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountResetPasswordConfirmation(SmartAppInfo manifest)
        {
            var template = new ResetPasswordConfirmation(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountResetPassword(SmartAppInfo manifest)
        {
            var template = new ResetPassword(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountRegister(SmartAppInfo manifest)
        {
            var template = new Register(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountLogin(SmartAppInfo manifest)
        {
            var template = new Login(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountLockout(SmartAppInfo manifest)
        {
            var template = new Lockout(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountForgotPasswordConfirmation(SmartAppInfo manifest)
        {
            var template = new ForgotPasswordConfirmation(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountForgotPassword(SmartAppInfo manifest)
        {
            var template = new ForgotPassword(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountExternalLoginFailure(SmartAppInfo manifest)
        {
            var template = new ExternalLoginFailure(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountExternalLoginConfirmation(SmartAppInfo manifest)
        {
            var template = new ExternalLoginConfirmation(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountConfirmEmail(SmartAppInfo manifest)
        {
            var template = new ConfirmEmail(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformViewsAccountAccessDenied(SmartAppInfo manifest)
        {
            var template = new AccessDenied(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformServicesSmsSender(SmartAppInfo manifest)
        {
            var template = new SmsSender(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformServicesMessageServices(SmartAppInfo manifest)
        {
            var template = new MessageServices(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformServicesEmailSender(SmartAppInfo manifest)
        {
            var template = new EmailSender(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformModelsManageViewModel(SmartAppInfo manifest)
        {
            var template = new ManageViewModels(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformModelsApplicationUser(SmartAppInfo manifest)
        {
            var template = new ApplicationUser(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformModelsAdminViewModel(SmartAppInfo manifest)
        {
            var template = new AdminViewModel(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformModelsAccountViewModel(SmartAppInfo manifest)
        {
            var template = new AccountViewModels(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformDataRepositoryTemplate(SmartAppInfo manifest)
        {
            var template = new RepositoryTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformDataIRepositoryTemplate(SmartAppInfo manifest)
        {
            var template = new IRepositoryTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformControllersManageController(SmartAppInfo manifest)
        {
            var template = new ManageController(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformControllersHomeController(SmartAppInfo manifest)
        {
            var template = new HomeController(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformControllersControllerBase(SmartAppInfo manifest)
        {
            var template = new ControllerBase(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformControllersAccountController(SmartAppInfo manifest)
        {
            var template = new AccountController(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformProgramTemplate(SmartAppInfo manifest)
        {
            var template = new ProgramTemplate(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformProject(SmartAppInfo manifest)
        {
            var template = new Project(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformStartup(SmartAppInfo manifest)
        {
            var template = new Startup(manifest);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformAppSettings(SmartAppInfo manifest)
        {
            var authenticationKeys = _context.DynamicContext.AuthenticationKeys as IDictionary<string, string>;
            var template = new AppSettingsTemplate(manifest, authenticationKeys);
            _writingService.WriteFile(Path.Combine(_context.BasePath, template.OutputPath), template.TransformText());
        }
    }
}
