using Mobioos.Foundation.Jade.Models;
using System;
using Xunit;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class CommonGeneratorTests : BaseGeneratorTests, IDisposable
    {
        [Fact]
        public void Startup_Template_Test()
        {
            var template = new Startup(new SmartAppInfo() { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend", output);
        }

        [Fact]
        public void Startup_Template_NullParameter_Test()
        {
            var template = new Startup(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void Project_Template_Test()
        {
            var template = new Project(new SmartAppInfo() { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void Project_Template_NullParameter_Test()
        {
            Assert.Throws<NullReferenceException>(()=> new Project(null));
        }

        [Fact]
        public void Program_Template_Test()
        {
            var template = new ProgramTemplate(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend", output);
        }

        [Fact]
        public void Program_Template_NullParameter_Test()
        {
            var template = new ProgramTemplate(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void AccountController_Template_Test()
        {
            var template = new AccountController(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
        }

        [Fact]
        public void AccountController_Template_NullParameter_Test()
        {
            var template = new AccountController(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ControllerBase_Template_Test()
        {
            var template = new ControllerBase(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
            Assert.Contains("public abstract partial class ControllerBase<T> : Controller where T : class", output);
        }

        [Fact]
        public void ControllerBase_Template_NullParameter_Test()
        {
            var template = new ControllerBase(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void HomeController_Template_Test()
        {
            var template = new HomeController(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
            Assert.Contains("public partial class HomeController : Controller", output);
        }

        [Fact]
        public void HomeController_Template_NullParameter_Test()
        {
            var template = new HomeController(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageController_Template_Test()
        {
            var template = new ManageController(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
            Assert.Contains("public partial class ManageController : Controller", output);
        }

        [Fact]
        public void ManageController_Template_NullParameter_Test()
        {
            var template = new ManageController(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void RoleAdminController_Template_Test()
        {
            var template = new RoleAdminController(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Controllers", output);
            Assert.Contains("public partial class RoleAdminController : Controller", output);
        }

        [Fact]
        public void RoleAdminController_Template_NullParameter_Test()
        {
            var template = new RoleAdminController(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void IRepository_Template_Test()
        {
            var template = new IRepositoryTemplate(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend", output);
            Assert.Contains("public interface IRepository<T>", output);
        }

        [Fact]
        public void IRepository_Template_NullParameter_Test()
        {
            var template = new IRepositoryTemplate(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void Repository_Template_Test()
        {
            var template = new RepositoryTemplate(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend", output);
            Assert.Contains("public class Repository<T> : IRepository<T>", output);
        }

        [Fact]
        public void Repository_Template_NullParameter_Test()
        {
            var template = new RepositoryTemplate(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void AccountViewModel_Template_Test()
        {
            var template = new AccountViewModels(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void AccountViewModel_Template_NullParameter_Test()
        {
            var template = new AccountViewModels(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void AdminViewModel_Template_Test()
        {
            var template = new AdminViewModel(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void AdminViewModel_Template_NullParameter_Test()
        {
            var template = new AdminViewModel(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ApplicationUser_Template_Test()
        {
            var template = new ApplicationUser(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
            Assert.Contains("public class ApplicationUser : IdentityUser", output);
        }

        [Fact]
        public void ApplicationUser_Template_NullParameter_Test()
        {
            var template = new ApplicationUser(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageViewModel_Template_Test()
        {
            var template = new ManageViewModels(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void ManageViewModel_Template_NullParameter_Test()
        {
            var template = new ManageViewModels(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ViewStart_Template_Test()
        {
            var template = new ViewStart(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ViewStart_Template_NullParameter_Test()
        {
            var template = new ViewStart(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ViewImports_Template_Test()
        {
            var template = new ViewImports(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@using {ApplicationId}.Backend", output);
            Assert.Contains($"@using {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void ViewImports_Template_NullParameter_Test()
        {
            var template = new ViewImports(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ErrorView_Template_Test()
        {
            var template = new Error(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ErrorView_Template_NullParameter_Test()
        {
            var template = new Error(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void LayoutView_Template_Test()
        {
            var template = new LayoutTemplate(new SmartAppInfo { Id = ApplicationId });
            Assert.Throws<ArgumentNullException>(() => template.TransformText());
        }

        [Fact]
        public void LayoutView_Template_NullParameter_Test()
        {
            var template = new LayoutTemplate(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void LoginPartialView_Template_Test()
        {
            var template = new LoginPartial(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@using {ApplicationId}.Backend.Models", output);
        }

        [Fact]
        public void LoginPartialView_Template_NullParameter_Test()
        {
            var template = new LoginPartial(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ValidationScriptsPartial_Template_Test()
        {
            var template = new LoginPartial(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ValidationScriptsPartial_Template_NullParameter_Test()
        {
            var template = new ValidationScriptsPartial(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void AccessDeniedView_Template_Test()
        {
            var template = new AccessDenied(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void AccessDeniedView_Template_NullParameter_Test()
        {
            var template = new AccessDenied(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ConfirmEmailView_Template_Test()
        {
            var template = new ConfirmEmail(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ConfirmEmailView_Template_NullParameter_Test()
        {
            var template = new ConfirmEmail(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ExternalLoginConfirmationView_Template_Test()
        {
            var template = new ExternalLoginConfirmation(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ExternalLoginConfirmationViewModel", output);
        }

        [Fact]
        public void ExternalLoginConfirmationView_Template_NullParameter_Test()
        {
            var template = new ExternalLoginConfirmation(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ExternalLoginFailureView_Template_Test()
        {
            var template = new ExternalLoginFailure(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ExternalLoginFailureView_Template_NullParameter_Test()
        {
            var template = new ExternalLoginFailure(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ForgotPasswordView_Template_Test()
        {
            var template = new ForgotPassword(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ForgotPasswordViewModel", output);
        }

        [Fact]
        public void ForgotPasswordView_Template_NullParameter_Test()
        {
            var template = new ForgotPassword(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ForgotPasswordConfirmationView_Template_Test()
        {
            var template = new ForgotPasswordConfirmation(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ForgotPasswordConfirmationView_Template_NullParameter_Test()
        {
            var template = new ForgotPasswordConfirmation(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void Lockout_Template_Test()
        {
            var template = new Lockout(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void Lockout_Template_NullParameter_Test()
        {
            var template = new Lockout(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void LoginView_Template_Test()
        {
            var template = new Login(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.LoginViewModel", output);
        }

        [Fact]
        public void LoginView_Template_NullParameter_Test()
        {
            var template = new Login(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void RegisterView_Template_Test()
        {
            var template = new Register(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.RegisterViewModel", output);
        }

        [Fact]
        public void RegisterView_Template_NullParameter_Test()
        {
            var template = new Register(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ResetPasswordView_Template_Test()
        {
            var template = new ResetPassword(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ResetPasswordViewModel", output);
        }

        [Fact]
        public void ResetPasswordView_Template_NullParameter_Test()
        {
            var template = new ResetPassword(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ResetPasswordConfirmationView_Template_Test()
        {
            var template = new ResetPasswordConfirmation(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ResetPasswordConfirmationView_Template_NullParameter_Test()
        {
            var template = new ResetPasswordConfirmation(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void SendCodeView_Template_Test()
        {
            var template = new SendCode(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.SendCodeViewModel", output);
        }

        [Fact]
        public void SendCodeView_Template_NullParameter_Test()
        {
            var template = new SendCode(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void VerifyCodeView_Template_Test()
        {
            var template = new VerifyCode(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.VerifyCodeViewModel", output);
        }

        [Fact]
        public void VerifyCodeView_Template_NullParameter_Test()
        {
            var template = new VerifyCode(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void HomeIndex_Template_Test()
        {
            var template = new HomeIndex(GetContext().DynamicContext.Manifest);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeIndex_Template_NullParameter_Test()
        {
            var template = new HomeIndex(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void HomeAbout_Template_Test()
        {
            var template = new HomeAbout(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeAbout_Template_NullParameter_Test()
        {
            var template = new HomeAbout(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeContact_Template_Test()
        {
            var template = new HomeContact(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeContact_Template_NullParameter_Test()
        {
            var template = new HomeContact(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeDashboard_Template_Test()
        {
            var template = new HomeDashboard(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void HomeDashboard_Template_NullParameter_Test()
        {
            var template = new HomeDashboard(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void ManageAddPhoneNumber_Template_Test()
        {
            var template = new ManageAddPhoneNumber(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.AddPhoneNumberViewModel", output);
        }

        [Fact]
        public void ManageAddPhoneNumber_Template_NullParameter_Test()
        {
            var template = new ManageAddPhoneNumber(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageChangePassword_Template_Test()
        {
            var template = new ManageChangePassword(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ChangePasswordViewModel", output);
        }

        [Fact]
        public void ManageChangePassword_Template_NullParameter_Test()
        {
            var template = new ManageChangePassword(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageIndex_Template_Test()
        {
            var template = new ManageIndex(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.IndexViewModel", output);
        }

        [Fact]
        public void ManageIndex_Template_NullParameter_Test()
        {
            var template = new ManageIndex(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageLogins_Template_Test()
        {
            var template = new ManageLogins(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ManageLoginsViewModel", output);
        }

        [Fact]
        public void ManageLogins_Template_NullParameter_Test()
        {
            var template = new ManageLogins(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageSetPassword_Template_Test()
        {
            var template = new ManageLogins(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.ManageLoginsViewModel", output);
        }

        [Fact]
        public void ManageSetPassword_Template_NullParameter_Test()
        {
            var template = new ManageSetPassword(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void ManageVerifyPhoneNumber_Template_Test()
        {
            var template = new ManageVerifyPhoneNumber(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.VerifyPhoneNumberViewModel", output);
        }

        [Fact]
        public void ManageVerifyPhoneNumber_Template_NullParameter_Test()
        {
            var template = new ManageVerifyPhoneNumber(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void RoleCreate_Template_Test()
        {
            var template = new RoleCreate(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.RoleViewModel", output);
        }

        [Fact]
        public void RoleCreate_Template_NullParameter_Test()
        {
            var template = new RoleCreate(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void RoleDelete_Template_Test()
        {
            var template = new RoleDelete(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains("@model Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", output);
        }

        [Fact]
        public void RoleDelete_Template_NullParameter_Test()
        {
            var template = new RoleDelete(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void RoleDetails_Template_Test()
        {
            var template = new RoleDetails(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains("@model Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", output);
        }

        [Fact]
        public void RoleDetails_Template_NullParameter_Test()
        {
            var template = new RoleDetails(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        [Fact]
        public void RoleEdit_Template_Test()
        {
            var template = new RoleEdit(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"@model {ApplicationId}.Backend.Models.RoleViewModel", output);
        }

        [Fact]
        public void RoleEdit_Template_NullParameter_Test()
        {
            var template = new RoleEdit(null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void RoleIndex_Template_Test()
        {
            var template = new RoleIndex(new SmartAppInfo { Id = ApplicationId });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains("@model IEnumerable<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole>", output);
        }

        [Fact]
        public void RoleIndex_Template_NullParameter_Test()
        {
            var template = new RoleIndex(null);
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
