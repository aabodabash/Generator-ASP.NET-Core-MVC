﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime : 15.0.0.0
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
    using Mobioos.Foundation.Jade.Extensions;
    using Mobioos.Scaffold.TextTemplating;
    using Mobioos.Generators.AspNetCore;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\DEV\Generators\Mobioos\Common\Templates\Services\MessageServices.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class MessageServices : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 1 "D:\DEV\Generators\Mobioos\Common\Templates\Services\MessageServices.tt"
 var model = (SmartAppInfo)Model; 
            
            #line default
            #line hidden
            this.Write("using System.Threading.Tasks;\r\nusing ");
            
            #line 3 "D:\DEV\Generators\Mobioos\Common\Templates\Services\MessageServices.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Infrastructure.Services;\r\n\r\nnamespace ");
            
            #line 5 "D:\DEV\Generators\Mobioos\Common\Templates\Services\MessageServices.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(@".Backend.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}