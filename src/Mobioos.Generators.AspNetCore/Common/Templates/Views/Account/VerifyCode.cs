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
    
    #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Views\Account\VerifyCode.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class VerifyCode : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Views\Account\VerifyCode.tt"
 var model = (SmartAppInfo)Model; 
            
            #line default
            #line hidden
            this.Write("@model ");
            
            #line 3 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Common\Templates\Views\Account\VerifyCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Models.VerifyCodeViewModel\r\n@{\r\n    ViewData[\"Title\"] = \"Verify\";\r\n}\r\n\r\n" +
                    "<h2>@ViewData[\"Title\"].</h2>\r\n\r\n<form\r\n    asp-controller=\"GeneratorAccount\"\r\n  " +
                    "  asp-action=\"VerifyCode\"\r\n    asp-route-returnurl=\"@Model.ReturnUrl\"\r\n    metho" +
                    "d=\"post\"\r\n    class=\"form-horizontal\">\r\n    <div\r\n        asp-validation-summary" +
                    "=\"All\"\r\n        class=\"text-danger\"></div>\r\n    <input\r\n        asp-for=\"Provide" +
                    "r\"\r\n        type=\"hidden\" />\r\n    <input\r\n        asp-for=\"RememberMe\"\r\n        " +
                    "type=\"hidden\" />\r\n    <h4>@ViewData[\"Status\"]</h4>\r\n    <hr/>\r\n    <div class=\"f" +
                    "orm-group\">\r\n        <label\r\n            asp-for=\"Code\"\r\n            class=\"col-" +
                    "md-2 control-label\"></label>\r\n        <div class=\"col-md-10\">\r\n            <inpu" +
                    "t\r\n                asp-for=\"Code\"\r\n                class=\"form-control\" />\r\n    " +
                    "        <span\r\n                asp-validation-for=\"Code\"\r\n                class=" +
                    "\"text-danger\"></span>\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r" +
                    "\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <div class=\"checkb" +
                    "ox\">\r\n                <input asp-for=\"RememberBrowser\" />\r\n                <labe" +
                    "l asp-for=\"RememberBrowser\"></label>\r\n            </div>\r\n        </div>\r\n    </" +
                    "div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-1" +
                    "0\">\r\n            <button\r\n                type=\"submit\"\r\n                class=\"" +
                    "btn btn-default\">Submit</button>\r\n        </div>\r\n    </div>\r\n</form>\r\n\r\n@sectio" +
                    "n Scripts\r\n{\r\n    @{\r\n        await Html.RenderPartialAsync(\"_ValidationScriptsP" +
                    "artial\");\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}