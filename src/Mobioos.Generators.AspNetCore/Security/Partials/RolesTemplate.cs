using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RolesTemplate : TemplateBase
    {
        public List<string> Roles { get; set; }

        public RolesTemplate(
            SmartAppInfo model,
            List<string> roles)
            : base(model)
        {
            Roles = roles;
        }

        public override string OutputPath => "Security\\Roles.cs";
    }
}
