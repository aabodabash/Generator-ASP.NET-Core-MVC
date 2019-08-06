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
    
    #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ApiDeleteTemplate : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 2 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"

    var action = (ApiActionInfo)Model;

    var firstParameter = action
        .Parameters
        .FirstOrDefault();

    var keyProperty = firstParameter?
        .DataModel?
        .GetProperties()
        .FirstOrDefault(p => p.IsKey);

    var keyType = keyProperty != null ?
        keyProperty
            .ModelProperty?
            .Substring(
                0,
                keyProperty.ModelProperty.IndexOf(".")) :
        "";

    if (string.IsNullOrEmpty(keyType))
    {
        var reference = action
            .ReturnType?
            .GetEntityDirectReferences()
            .FirstOrDefault(p => !p.IsAbstract);

        keyType = reference?
            .Id?
            .CSharpType();

        keyProperty = reference?
            .GetProperties()
            .FirstOrDefault(p => p.IsKey);
    }

            
            #line default
            #line hidden
            this.Write("        {\r\n            try\r\n            {\r\n");
            
            #line 41 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"

    if (!string.IsNullOrEmpty(keyType))
    {

            
            #line default
            #line hidden
            this.Write("                var entity = await _");
            
            #line 45 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyType));
            
            #line default
            #line hidden
            this.Write("Service.GetById(");
            
            #line 45 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(firstParameter.Id));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 45 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Id));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n                if (entity == null)\r\n                {\r\n                   " +
                    " return NotFound();\r\n                }\r\n\r\n                await _");
            
            #line 52 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyType));
            
            #line default
            #line hidden
            this.Write("Service.Delete(");
            
            #line 52 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(firstParameter.Id));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 52 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(keyProperty.Id));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n                return Ok(entity);\r\n");
            
            #line 55 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"

    }
    else if (firstParameter?.DataModel != null) {

            
            #line default
            #line hidden
            this.Write("                return Ok(new ");
            
            #line 59 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(firstParameter.DataModel.Id));
            
            #line default
            #line hidden
            this.Write("());\r\n");
            
            #line 60 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"

    }
    else
    {

            
            #line default
            #line hidden
            this.Write("                return Ok(true);\r\n");
            
            #line 66 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Mobioos.Generators.AspNetCore\Api\Templates\Api\ApiDeleteTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("            }\r\n            catch (Exception xcp)\r\n            {\r\n                " +
                    "return StatusCode((int)HttpStatusCode.InternalServerError);\r\n            }\r\n    " +
                    "    }");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}