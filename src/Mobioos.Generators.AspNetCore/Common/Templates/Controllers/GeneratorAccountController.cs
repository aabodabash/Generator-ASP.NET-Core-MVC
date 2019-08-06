﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime : 16.0.0.0
//  
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Mobioos.Generators.AspNetCore
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Mobioos.Foundation.Jade.Models;
    using Mobioos.Scaffold.BaseGenerators.TextTemplating;
    using Common.Generator.Framework.Extensions;
    using Mobioos.Generators.AspNetCore;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class GeneratorAccountController : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
 var model = (SmartAppInfo)Model; 
            
            #line default
            #line hidden
            this.Write(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ");
            
            #line 15 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Models;\r\nusing ");
            
            #line 16 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Helpers;\r\nusing ");
            
            #line 17 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Infrastructure.Services;\r\n\r\nnamespace ");
            
            #line 19 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Controllers\GeneratorAccountController.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Controllers\r\n{\r\n    [Authorize]\r\n    public class GeneratorAccountContro" +
                    "ller : Controller\r\n    {\r\n        private readonly UserManager<ApplicationUser> " +
                    "_userManager;\r\n        private readonly SignInManager<ApplicationUser> _signInMa" +
                    "nager;\r\n        private readonly IEmailSender _emailSender;\r\n        private rea" +
                    "donly ISmsSender _smsSender;\r\n        private readonly ILogger _logger;\r\n\r\n     " +
                    "   public GeneratorAccountController(\r\n            UserManager<ApplicationUser> " +
                    "userManager,\r\n            SignInManager<ApplicationUser> signInManager,\r\n       " +
                    "     IEmailSender emailSender,\r\n            ISmsSender smsSender,\r\n            I" +
                    "LoggerFactory loggerFactory)\r\n        {\r\n            _userManager = userManager;" +
                    "\r\n            _signInManager = signInManager;\r\n            _emailSender = emailS" +
                    "ender;\r\n            _smsSender = smsSender;\r\n            _logger = loggerFactory" +
                    ".CreateLogger<GeneratorAccountController>();\r\n        }\r\n\r\n        // GET: /Gene" +
                    "ratorAccount/Login\r\n        [HttpGet]\r\n        [AllowAnonymous]\r\n        public " +
                    "async Task<IActionResult> Login(string returnUrl = null)\r\n        {\r\n           " +
                    " // Clear the existing external cookie to ensure a clean login process\r\n        " +
                    "    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);\r\n\r\n       " +
                    "     ViewData[\"ReturnUrl\"] = returnUrl;\r\n            return View();\r\n        }\r\n" +
                    "\r\n        // POST: /GeneratorAccount/Login\r\n        [HttpPost]\r\n        [AllowAn" +
                    "onymous]\r\n        [ValidateAntiForgeryToken]\r\n        public async Task<IActionR" +
                    "esult> Login(\r\n            LoginViewModel model,\r\n            string returnUrl =" +
                    " null)\r\n        {\r\n            ViewData[\"ReturnUrl\"] = returnUrl;\r\n\r\n           " +
                    " if (ModelState.IsValid)\r\n            {\r\n                // This doesn\'t count l" +
                    "ogin failures towards account lockout\r\n                // To enable password fai" +
                    "lures to trigger account lockout, set lockoutOnFailure: true\r\n                va" +
                    "r result = await _signInManager.PasswordSignInAsync(\r\n                    model." +
                    "Email,\r\n                    model.Password,\r\n                    model.RememberM" +
                    "e,\r\n                    lockoutOnFailure: false);\r\n\r\n                if (result." +
                    "Succeeded)\r\n                {\r\n                    _logger.LogInformation(\r\n    " +
                    "                    1,\r\n                        \"User logged in.\");\r\n\r\n         " +
                    "           return RedirectToLocal(returnUrl);\r\n                }\r\n\r\n            " +
                    "    if (result.RequiresTwoFactor)\r\n                {\r\n                    return" +
                    " RedirectToAction(\r\n                        nameof(SendCode),\r\n                 " +
                    "       new\r\n                        {\r\n                            ReturnUrl = r" +
                    "eturnUrl,\r\n                            RememberMe = model.RememberMe\r\n          " +
                    "              });\r\n                }\r\n\r\n                if (result.IsLockedOut)\r" +
                    "\n                {\r\n                    _logger.LogWarning(\r\n                   " +
                    "     2,\r\n                        \"User account locked out.\");\r\n\r\n               " +
                    "     return View(\"Lockout\");\r\n                }\r\n                else\r\n         " +
                    "       {\r\n                    ModelState.AddModelError(\r\n                       " +
                    " string.Empty,\r\n                        \"Invalid login attempt.\");\r\n\r\n          " +
                    "          return View(model);\r\n                }\r\n            }\r\n\r\n            /" +
                    "/ If we got this far, something failed, redisplay form\r\n            return View(" +
                    "model);\r\n        }\r\n\r\n        // GET: /GeneratorAccount/Register\r\n        [HttpG" +
                    "et]\r\n        [AllowAnonymous]\r\n        public IActionResult Register(string retu" +
                    "rnUrl = null)\r\n        {\r\n            ViewData[\"ReturnUrl\"] = returnUrl;\r\n      " +
                    "      return View();\r\n        }\r\n\r\n        // POST: /GeneratorAccount/Register\r\n" +
                    "        [HttpPost]\r\n        [AllowAnonymous]\r\n        [ValidateAntiForgeryToken]" +
                    "\r\n        public async Task<IActionResult> Register(\r\n            RegisterViewMo" +
                    "del model,\r\n            string returnUrl = null)\r\n        {\r\n            ViewDat" +
                    "a[\"ReturnUrl\"] = returnUrl;\r\n\r\n            if (ModelState.IsValid)\r\n            " +
                    "{\r\n                var user = new ApplicationUser\r\n                {\r\n          " +
                    "          UserName = model.Email,\r\n                    Email = model.Email\r\n    " +
                    "            };\r\n\r\n                var result = await _userManager.CreateAsync(\r\n" +
                    "                    user,\r\n                    model.Password);\r\n\r\n             " +
                    "   if (result.Succeeded)\r\n                {\r\n                    // For more inf" +
                    "ormation on how to enable account confirmation\r\n                    // and passw" +
                    "ord reset please visit https://go.microsoft.com/fwlink/?LinkID=532713\r\n         " +
                    "           // Send an email with this link\r\n\r\n                    // var code = " +
                    "await _userManager.GenerateEmailConfirmationTokenAsync(user);\r\n\r\n               " +
                    "     // var callbackUrl = Url.Action(\r\n                    //     nameof(Confirm" +
                    "Email),\r\n                    //     \"Account\",\r\n                    //     new\r\n" +
                    "                    //     {\r\n                    //         userId = user.Id,\r\n" +
                    "                    //         code = code\r\n                    //     },\r\n     " +
                    "               //     protocol: HttpContext.Request.Scheme);\r\n\r\n                " +
                    "    // await _emailSender.SendEmailAsync(\r\n                    //     model.Emai" +
                    "l,\r\n                    //     \"Confirm your account\",\r\n                    //  " +
                    "   $\"Please confirm your account by clicking this link: <a href=\'{callbackUrl}\'>" +
                    "link</a>\");\r\n\r\n                    await _signInManager.SignInAsync(\r\n          " +
                    "              user,\r\n                        isPersistent: false);\r\n\r\n          " +
                    "          _logger.LogInformation(\r\n                        3,\r\n                 " +
                    "       \"User created a new account with password.\");\r\n\r\n                    retu" +
                    "rn RedirectToLocal(returnUrl);\r\n                }\r\n\r\n                AddErrors(r" +
                    "esult);\r\n            }\r\n\r\n            // If we got this far, something failed, r" +
                    "edisplay form\r\n            return View(model);\r\n        }\r\n\r\n        [HttpPost]\r" +
                    "\n        public async Task<IActionResult> Post([FromBody]RegisterViewModel model" +
                    ")\r\n        {\r\n            if (!ModelState.IsValid)\r\n            {\r\n             " +
                    "   return BadRequest(ModelState);\r\n            }\r\n\r\n            var userIdentity" +
                    " = new ApplicationUser\r\n            {\r\n                UserName = model.Email,\r\n" +
                    "                Email = model.Email\r\n            };\r\n\r\n            var result = " +
                    "await _userManager.CreateAsync(\r\n                userIdentity,\r\n                " +
                    "model.Password);\r\n\r\n            if (!result.Succeeded)\r\n            {\r\n         " +
                    "       return new BadRequestObjectResult(Errors.AddErrorsToModelState(\r\n        " +
                    "            result,\r\n                    ModelState));\r\n            }\r\n\r\n       " +
                    "     return new OkObjectResult(\"Account created\");\r\n        }\r\n\r\n        // POST" +
                    ": /GeneratorAccount/Logout\r\n        [HttpPost]\r\n        [ValidateAntiForgeryToke" +
                    "n]\r\n        public async Task<IActionResult> Logout()\r\n        {\r\n            aw" +
                    "ait _signInManager.SignOutAsync();\r\n\r\n            _logger.LogInformation(\r\n     " +
                    "           4,\r\n                \"User logged out.\");\r\n\r\n            return Redire" +
                    "ctToAction(\r\n                nameof(GeneratorHomeController.Index),\r\n           " +
                    "     \"GeneratorHome\");\r\n        }\r\n\r\n        // POST: /GeneratorAccount/External" +
                    "Login\r\n        [HttpPost]\r\n        [AllowAnonymous]\r\n        [ValidateAntiForger" +
                    "yToken]\r\n        public IActionResult ExternalLogin(\r\n            string provide" +
                    "r,\r\n            string returnUrl = null)\r\n        {\r\n            // Request a re" +
                    "direct to the external login provider.\r\n            var redirectUrl = Url.Action" +
                    "(\r\n                nameof(ExternalLoginCallback),\r\n                \"Account\",\r\n " +
                    "               new\r\n                {\r\n                    ReturnUrl = returnUrl" +
                    "\r\n                });\r\n\r\n            var properties = _signInManager.ConfigureEx" +
                    "ternalAuthenticationProperties(\r\n                provider,\r\n                redi" +
                    "rectUrl);\r\n\r\n            return Challenge(\r\n                properties,\r\n       " +
                    "         provider);\r\n        }\r\n\r\n        // GET: /GeneratorAccount/ExternalLogi" +
                    "nCallback\r\n        [HttpGet]\r\n        [AllowAnonymous]\r\n        public async Tas" +
                    "k<IActionResult> ExternalLoginCallback(\r\n            string returnUrl = null,\r\n " +
                    "           string remoteError = null)\r\n        {\r\n            if (remoteError !=" +
                    " null)\r\n            {\r\n                ModelState.AddModelError(\r\n              " +
                    "      string.Empty,\r\n                    $\"Error from external provider: {remote" +
                    "Error}\");\r\n\r\n                return View(nameof(Login));\r\n            }\r\n\r\n     " +
                    "       var info = await _signInManager.GetExternalLoginInfoAsync();\r\n\r\n         " +
                    "   if (info == null)\r\n            {\r\n                return RedirectToAction(nam" +
                    "eof(Login));\r\n            }\r\n\r\n            // Sign in the user with this externa" +
                    "l login provider if the user already has a login.\r\n            var result = awai" +
                    "t _signInManager.ExternalLoginSignInAsync(\r\n                info.LoginProvider,\r" +
                    "\n                info.ProviderKey,\r\n                isPersistent: false);\r\n\r\n   " +
                    "         if (result.Succeeded)\r\n            {\r\n                _logger.LogInform" +
                    "ation(\r\n                    5,\r\n                    \"User logged in with {Name} " +
                    "provider.\",\r\n                    info.LoginProvider);\r\n\r\n                return " +
                    "RedirectToLocal(returnUrl);\r\n            }\r\n\r\n            if (result.RequiresTwo" +
                    "Factor)\r\n            {\r\n                return RedirectToAction(\r\n              " +
                    "      nameof(SendCode),\r\n                    new\r\n                    {\r\n       " +
                    "                 ReturnUrl = returnUrl\r\n                    });\r\n            }\r\n" +
                    "\r\n            if (result.IsLockedOut)\r\n            {\r\n                return Vie" +
                    "w(\"Lockout\");\r\n            }\r\n\r\n            else\r\n            {\r\n               " +
                    " // If the user does not have an account, then ask the user to create an account" +
                    ".\r\n                ViewData[\"ReturnUrl\"] = returnUrl;\r\n                ViewData[" +
                    "\"LoginProvider\"] = info.LoginProvider;\r\n                var email = info.Princip" +
                    "al.FindFirstValue(ClaimTypes.Email);\r\n\r\n                return View(\r\n          " +
                    "          \"ExternalLoginConfirmation\",\r\n                    new ExternalLoginCon" +
                    "firmationViewModel\r\n                    {\r\n                        Email = email" +
                    "\r\n                    });\r\n            }\r\n        }\r\n\r\n        // POST: /Generat" +
                    "orAccount/ExternalLoginConfirmation\r\n        [HttpPost]\r\n        [AllowAnonymous" +
                    "]\r\n        [ValidateAntiForgeryToken]\r\n        public async Task<IActionResult> " +
                    "ExternalLoginConfirmation(\r\n            ExternalLoginConfirmationViewModel model" +
                    ",\r\n            string returnUrl = null)\r\n        {\r\n            if (ModelState.I" +
                    "sValid)\r\n            {\r\n                // Get the information about the user fr" +
                    "om the external login provider\r\n                var info = await _signInManager." +
                    "GetExternalLoginInfoAsync();\r\n\r\n                if (info == null)\r\n             " +
                    "   {\r\n                    return View(\"ExternalLoginFailure\");\r\n                " +
                    "}\r\n\r\n                var user = new ApplicationUser\r\n                {\r\n        " +
                    "            UserName = model.Email,\r\n                    Email = model.Email\r\n  " +
                    "              };\r\n\r\n                var result = await _userManager.CreateAsync(" +
                    "user);\r\n\r\n                if (result.Succeeded)\r\n                {\r\n            " +
                    "        result = await _userManager.AddLoginAsync(\r\n                        user" +
                    ",\r\n                        info);\r\n\r\n                    if (result.Succeeded)\r\n" +
                    "                    {\r\n                        await _signInManager.SignInAsync(" +
                    "\r\n                            user,\r\n                            isPersistent: f" +
                    "alse);\r\n\r\n                        _logger.LogInformation(\r\n                     " +
                    "       6,\r\n                            \"User created an account using {Name} pro" +
                    "vider.\",\r\n                            info.LoginProvider);\r\n\r\n                  " +
                    "      return RedirectToLocal(returnUrl);\r\n                    }\r\n               " +
                    " }\r\n\r\n                AddErrors(result);\r\n            }\r\n\r\n            ViewData[" +
                    "\"ReturnUrl\"] = returnUrl;\r\n            return View(model);\r\n        }\r\n\r\n       " +
                    " // GET: /GeneratorAccount/ConfirmEmail\r\n        [HttpGet]\r\n        [AllowAnonym" +
                    "ous]\r\n        public async Task<IActionResult> ConfirmEmail(\r\n            string" +
                    " userId,\r\n            string code)\r\n        {\r\n            if (userId == null\r\n " +
                    "               || code == null)\r\n            {\r\n                return View(\"Err" +
                    "or\");\r\n            }\r\n\r\n            var user = await _userManager.FindByIdAsync(" +
                    "userId);\r\n\r\n            if (user == null)\r\n            {\r\n                return" +
                    " View(\"Error\");\r\n            }\r\n\r\n            var result = await _userManager.Co" +
                    "nfirmEmailAsync(\r\n                user,\r\n                code);\r\n\r\n            r" +
                    "eturn View(result.Succeeded ?\r\n                \"ConfirmEmail\" : \"Error\");\r\n     " +
                    "   }\r\n\r\n        // GET: /GeneratorAccount/ForgotPassword\r\n        [HttpGet]\r\n   " +
                    "     [AllowAnonymous]\r\n        public IActionResult ForgotPassword()\r\n        {\r" +
                    "\n            return View();\r\n        }\r\n\r\n        // POST: /GeneratorAccount/For" +
                    "gotPassword\r\n        [HttpPost]\r\n        [AllowAnonymous]\r\n        [ValidateAnti" +
                    "ForgeryToken]\r\n        public async Task<IActionResult> ForgotPassword(ForgotPas" +
                    "swordViewModel model)\r\n        {\r\n            if (ModelState.IsValid)\r\n         " +
                    "   {\r\n                var user = await _userManager.FindByEmailAsync(model.Email" +
                    ");\r\n\r\n                if (user == null\r\n                    || !(await _userMana" +
                    "ger.IsEmailConfirmedAsync(user)))\r\n                {\r\n                    // Don" +
                    "\'t reveal that the user does not exist or is not confirmed\r\n                    " +
                    "return View(\"ForgotPasswordConfirmation\");\r\n                }\r\n\r\n               " +
                    " // For more information on how to enable account confirmation\r\n                " +
                    "// and password reset please visit https://go.microsoft.com/fwlink/?LinkID=53271" +
                    "3\r\n                // Send an email with this link\r\n\r\n                // var cod" +
                    "e = await _userManager.GeneratePasswordResetTokenAsync(user);\r\n\r\n               " +
                    " // var callbackUrl = Url.Action(\r\n                //     nameof(ResetPassword)," +
                    "\r\n                //     \"Account\",\r\n                //     new\r\n               " +
                    " //     {\r\n                //         userId = user.Id,\r\n                //     " +
                    "    code = code\r\n                //     },\r\n                //     protocol: Htt" +
                    "pContext.Request.Scheme);\r\n\r\n                // await _emailSender.SendEmailAsyn" +
                    "c(\r\n                //     model.Email,\r\n                //     \"Reset Password\"" +
                    ",\r\n                //     $\"Please reset your password by clicking here: <a href" +
                    "=\'{callbackUrl}\'>link</a>\");\r\n\r\n                // return View(\"ForgotPasswordCo" +
                    "nfirmation\");\r\n            }\r\n\r\n            // If we got this far, something fai" +
                    "led, redisplay form\r\n            return View(model);\r\n        }\r\n\r\n        // GE" +
                    "T: /GeneratorAccount/ForgotPasswordConfirmation\r\n        [HttpGet]\r\n        [All" +
                    "owAnonymous]\r\n        public IActionResult ForgotPasswordConfirmation()\r\n       " +
                    " {\r\n            return View();\r\n        }\r\n\r\n        // GET: /GeneratorAccount/R" +
                    "esetPassword\r\n        [HttpGet]\r\n        [AllowAnonymous]\r\n        public IActio" +
                    "nResult ResetPassword(string code = null)\r\n        {\r\n            return code ==" +
                    " null ?\r\n                View(\"Error\") : View();\r\n        }\r\n\r\n        // POST: " +
                    "/GeneratorAccount/ResetPassword\r\n        [HttpPost]\r\n        [AllowAnonymous]\r\n " +
                    "       [ValidateAntiForgeryToken]\r\n        public async Task<IActionResult> Rese" +
                    "tPassword(ResetPasswordViewModel model)\r\n        {\r\n            if (!ModelState." +
                    "IsValid)\r\n            {\r\n                return View(model);\r\n            }\r\n\r\n " +
                    "           var user = await _userManager.FindByEmailAsync(model.Email);\r\n\r\n     " +
                    "       if (user == null)\r\n            {\r\n                // Don\'t reveal that th" +
                    "e user does not exist\r\n                return RedirectToAction(\r\n               " +
                    "     nameof(GeneratorAccountController.ResetPasswordConfirmation),\r\n            " +
                    "        \"Account\");\r\n            }\r\n\r\n            var result = await _userManage" +
                    "r.ResetPasswordAsync(\r\n                user,\r\n                model.Code,\r\n     " +
                    "           model.Password);\r\n\r\n            if (result.Succeeded)\r\n            {\r" +
                    "\n                return RedirectToAction(\r\n                    nameof(GeneratorA" +
                    "ccountController.ResetPasswordConfirmation),\r\n                    \"Account\");\r\n " +
                    "           }\r\n\r\n            AddErrors(result);\r\n            return View();\r\n    " +
                    "    }\r\n\r\n        // GET: /GeneratorAccount/ResetPasswordConfirmation\r\n        [H" +
                    "ttpGet]\r\n        [AllowAnonymous]\r\n        public IActionResult ResetPasswordCon" +
                    "firmation()\r\n        {\r\n            return View();\r\n        }\r\n\r\n        // GET:" +
                    " /GeneratorAccount/SendCode\r\n        [HttpGet]\r\n        [AllowAnonymous]\r\n      " +
                    "  public async Task<ActionResult> SendCode(\r\n            string returnUrl = null" +
                    ",\r\n            bool rememberMe = false)\r\n        {\r\n            var user = await" +
                    " _signInManager.GetTwoFactorAuthenticationUserAsync();\r\n\r\n            if (user =" +
                    "= null)\r\n            {\r\n                return View(\"Error\");\r\n            }\r\n\r\n" +
                    "            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync" +
                    "(user);\r\n\r\n            var factorOptions = userFactors.Select(purpose =>\r\n      " +
                    "          new SelectListItem\r\n                {\r\n                    Text = purp" +
                    "ose,\r\n                    Value = purpose\r\n                }).ToList();\r\n\r\n     " +
                    "       return View(new SendCodeViewModel\r\n            {\r\n                Provide" +
                    "rs = factorOptions,\r\n                ReturnUrl = returnUrl,\r\n                Rem" +
                    "emberMe = rememberMe\r\n            });\r\n        }\r\n\r\n        // POST: /GeneratorA" +
                    "ccount/SendCode\r\n        [HttpPost]\r\n        [AllowAnonymous]\r\n        [Validate" +
                    "AntiForgeryToken]\r\n        public async Task<IActionResult> SendCode(SendCodeVie" +
                    "wModel model)\r\n        {\r\n            if (!ModelState.IsValid)\r\n            {\r\n " +
                    "               return View();\r\n            }\r\n\r\n            var user = await _si" +
                    "gnInManager.GetTwoFactorAuthenticationUserAsync();\r\n\r\n            if (user == nu" +
                    "ll)\r\n            {\r\n                return View(\"Error\");\r\n            }\r\n\r\n    " +
                    "        // Generate the token and send it\r\n            var code = await _userMan" +
                    "ager.GenerateTwoFactorTokenAsync(\r\n                user,\r\n                model." +
                    "SelectedProvider);\r\n\r\n            if (string.IsNullOrWhiteSpace(code))\r\n        " +
                    "    {\r\n                return View(\"Error\");\r\n            }\r\n\r\n            var m" +
                    "essage = $\"Your security code is: {code}\";\r\n\r\n            if (model.SelectedProv" +
                    "ider == \"Email\")\r\n            {\r\n                await _emailSender.SendEmailAsy" +
                    "nc(\r\n                    await _userManager.GetEmailAsync(user),\r\n              " +
                    "      \"Security Code\", message);\r\n            }\r\n            else if (model.Sele" +
                    "ctedProvider == \"Phone\")\r\n            {\r\n                await _smsSender.SendSm" +
                    "sAsync(\r\n                    await _userManager.GetPhoneNumberAsync(user),\r\n    " +
                    "                message);\r\n            }\r\n\r\n            return RedirectToAction(" +
                    "\r\n                nameof(VerifyCode),\r\n                new\r\n                {\r\n " +
                    "                   Provider = model.SelectedProvider,\r\n                    Retur" +
                    "nUrl = model.ReturnUrl,\r\n                    RememberMe = model.RememberMe\r\n    " +
                    "            });\r\n        }\r\n\r\n        // GET: /GeneratorAccount/VerifyCode\r\n    " +
                    "    [HttpGet]\r\n        [AllowAnonymous]\r\n        public async Task<IActionResult" +
                    "> VerifyCode(\r\n            string provider,\r\n            bool rememberMe,\r\n     " +
                    "       string returnUrl = null)\r\n        {\r\n            // Require that the user" +
                    " has already logged in via username/password or external login\r\n            var " +
                    "user = await _signInManager.GetTwoFactorAuthenticationUserAsync();\r\n\r\n          " +
                    "  if (user == null)\r\n            {\r\n                return View(\"Error\");\r\n     " +
                    "       }\r\n\r\n            return View(new VerifyCodeViewModel\r\n            {\r\n    " +
                    "            Provider = provider,\r\n                ReturnUrl = returnUrl,\r\n      " +
                    "          RememberMe = rememberMe\r\n            });\r\n        }\r\n\r\n        // POST" +
                    ": /GeneratorAccount/VerifyCode\r\n        [HttpPost]\r\n        [AllowAnonymous]\r\n  " +
                    "      [ValidateAntiForgeryToken]\r\n        public async Task<IActionResult> Verif" +
                    "yCode(VerifyCodeViewModel model)\r\n        {\r\n            if (!ModelState.IsValid" +
                    ")\r\n            {\r\n                return View(model);\r\n            }\r\n\r\n        " +
                    "    // The following code protects for brute force attacks against the two facto" +
                    "r codes.\r\n            // If a user enters incorrect codes for a specified amount" +
                    " of time then the user account\r\n            // will be locked out for a specifie" +
                    "d amount of time.\r\n            var result = await _signInManager.TwoFactorSignIn" +
                    "Async(\r\n                model.Provider,\r\n                model.Code,\r\n          " +
                    "      model.RememberMe,\r\n                model.RememberBrowser);\r\n\r\n            " +
                    "if (result.Succeeded)\r\n            {\r\n                return RedirectToLocal(mod" +
                    "el.ReturnUrl);\r\n            }\r\n\r\n            if (result.IsLockedOut)\r\n          " +
                    "  {\r\n                _logger.LogWarning(\r\n                    7,\r\n              " +
                    "      \"User account locked out.\");\r\n\r\n                return View(\"Lockout\");\r\n " +
                    "           }\r\n            else\r\n            {\r\n                ModelState.AddMod" +
                    "elError(\r\n                    string.Empty,\r\n                    \"Invalid code.\"" +
                    ");\r\n\r\n                return View(model);\r\n            }\r\n        }\r\n\r\n        /" +
                    "/ GET /GeneratorAccount/AccessDenied\r\n        [HttpGet]\r\n        public IActionR" +
                    "esult AccessDenied()\r\n        {\r\n            return View();\r\n        }\r\n\r\n      " +
                    "  #region Helpers\r\n\r\n        private void AddErrors(IdentityResult result)\r\n    " +
                    "    {\r\n            foreach (var error in result.Errors)\r\n            {\r\n        " +
                    "        ModelState.AddModelError(\r\n                    string.Empty,\r\n          " +
                    "          error.Description);\r\n            }\r\n        }\r\n\r\n        private IActi" +
                    "onResult RedirectToLocal(string returnUrl)\r\n        {\r\n            if (Url.IsLoc" +
                    "alUrl(returnUrl))\r\n            {\r\n                return Redirect(returnUrl);\r\n " +
                    "           }\r\n            else\r\n            {\r\n                return RedirectTo" +
                    "Action(\r\n                    nameof(GeneratorHomeController.Index),\r\n           " +
                    "         \"GeneratorHome\");\r\n            }\r\n        }\r\n\r\n        #endregion\r\n    " +
                    "}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}