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
    using Mobioos.Scaffold.BaseGenerators.TextTemplating;
    using Mobioos.Generators.AspNetCore;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Common\Templates\Views\Manage\ManageSetPassword.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ManageSetPassword : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Common\Templates\Views\Manage\ManageSetPassword.tt"
 var model = (SmartAppInfo)Model; 
            
            #line default
            #line hidden
            this.Write("@model ");
            
            #line 2 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Common\Templates\Views\Manage\ManageSetPassword.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(@".Backend.Models.SetPasswordViewModel
@{
    ViewData[""Title""] = ""Set Password"";
}

<p class=""text-info"">
    You do not have a local username/password for this site. Add a local
    account so you can log in without an external login.
</p>

<form asp-controller=""Manage"" asp-action=""SetPassword"" asp-route-returnurl=""@ViewData[""ReturnUrl""]"" method=""post"" class=""form-horizontal"">
    <h4>Set your password</h4>
    <hr />
    <div asp-validation-summary=""All"" class=""text-danger""></div>
    <div class=""form-group"">
        <label asp-for=""NewPassword"" class=""col-md-2 control-label""></label>
        <div class=""col-md-10"">
            <input asp-for=""NewPassword"" class=""form-control"" />
            <span asp-validation-for=""NewPassword"" class=""text-danger""></span>
        </div>
    </div>
    <div class=""form-group"">
        <label asp-for=""ConfirmPassword"" class=""col-md-2 control-label""></label>
        <div class=""col-md-10"">
            <input asp-for=""ConfirmPassword"" class=""form-control"" />
            <span asp-validation-for=""ConfirmPassword"" class=""text-danger""></span>
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10"">
            <button type=""submit"" class=""btn btn-default"">Set password</button>
        </div>
    </div>
</form>

@section Scripts {
    @{ await Html.RenderPartialAsync(""_ValidationScriptsPartial""); }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
