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
    
    #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Security\Templates\JwtFactory.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class JwtFactory : TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n");
            
            #line 1 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Security\Templates\JwtFactory.tt"
 var model = (SmartAppInfo)Model; 
            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.IdentityModel.Tokens.Jwt;\r\nusing System.Security.Clai" +
                    "ms;\r\nusing System.Security.Principal;\r\nusing System.Threading.Tasks;\r\nusing Micr" +
                    "osoft.Extensions.Options;\r\nusing ");
            
            #line 8 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Security\Templates\JwtFactory.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Models;\r\nusing ");
            
            #line 9 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Security\Templates\JwtFactory.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Helpers;\r\n\r\nnamespace ");
            
            #line 11 "C:\Users\PC\Documents\Gits\ASP.NET-Core-MVC\src\Security\Templates\JwtFactory.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(model.Id));
            
            #line default
            #line hidden
            this.Write(".Backend.Auth\r\n{\r\n\tpublic class JwtFactory : IJwtFactory\r\n    {\r\n        private " +
                    "readonly JwtIssuerOptions _jwtOptions;\r\n\r\n        public JwtFactory(IOptions<Jwt" +
                    "IssuerOptions> jwtOptions)\r\n        {\r\n            _jwtOptions = jwtOptions.Valu" +
                    "e;\r\n            ThrowIfInvalidOptions(_jwtOptions);\r\n        }\r\n\r\n        public" +
                    " async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identit" +
                    "y)\r\n        {\r\n            var claims = new[]\r\n\t\t\t{\r\n                 new Claim(" +
                    "JwtRegisteredClaimNames.Sub, userName),\r\n                 new Claim(JwtRegistere" +
                    "dClaimNames.Jti, await _jwtOptions.JtiGenerator()),\r\n                 new Claim(" +
                    "JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), C" +
                    "laimValueTypes.Integer64),\r\n                 identity.FindFirst(Helpers.Constant" +
                    "s.Strings.JwtClaimIdentifiers.Rol),\r\n                 identity.FindFirst(Helpers" +
                    ".Constants.Strings.JwtClaimIdentifiers.Id)\r\n            };\r\n\r\n\r\n            // C" +
                    "reate the JWT security token and encode it.\r\n            var jwt = new JwtSecuri" +
                    "tyToken(\r\n                issuer: _jwtOptions.Issuer,\r\n                audience:" +
                    " _jwtOptions.Audience,\r\n                claims: claims,\r\n                notBefo" +
                    "re: _jwtOptions.NotBefore,\r\n                expires: _jwtOptions.Expiration,\r\n  " +
                    "              signingCredentials: _jwtOptions.SigningCredentials);\r\n\r\n          " +
                    "  var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);\r\n\r\n           " +
                    " return encodedJwt;\r\n        }\r\n\r\n\r\n        public ClaimsIdentity GenerateClaims" +
                    "Identity(string userName, string id)\r\n        {\r\n            return new ClaimsId" +
                    "entity(new GenericIdentity(userName, \"Token\"), new[]\r\n            {\r\n           " +
                    "     new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Id, id),\r\n         " +
                    "       new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol, Helpers.Cons" +
                    "tants.Strings.JwtClaims.ApiAccess)\r\n            });\r\n        }\r\n\r\n\r\n        /// " +
                    "<returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC)." +
                    "</returns>\r\n        private static long ToUnixEpochDate(DateTime date)\r\n        " +
                    "  => (long)Math.Round((date.ToUniversalTime() -\r\n                               " +
                    "new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))\r\n                       " +
                    "       .TotalSeconds);\r\n\r\n\r\n        private static void ThrowIfInvalidOptions(Jw" +
                    "tIssuerOptions options)\r\n        {\r\n            if (options == null) throw new A" +
                    "rgumentNullException(nameof(options));\r\n\r\n            if (options.ValidFor <= Ti" +
                    "meSpan.Zero)\r\n            {\r\n                throw new ArgumentException(\"Must b" +
                    "e a non-zero TimeSpan.\", nameof(JwtIssuerOptions.ValidFor));\r\n            }\r\n\r\n " +
                    "           if (options.SigningCredentials == null)\r\n            {\r\n             " +
                    "   throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));" +
                    "\r\n            }\r\n\r\n            if (options.JtiGenerator == null)\r\n            {\r" +
                    "\n                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGene" +
                    "rator));\r\n            }\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
