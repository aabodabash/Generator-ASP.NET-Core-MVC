using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(SecurityActivity), Order = 2)]
    public partial class RolesTemplate : TemplateBase
    {
        public RolesTemplate(SmartAppInfo model, List<string> roles) : base(model)
        {
            Roles = roles;
        }

        public List<string> Roles { get; set; }

        public override string OutputPath => "Security\\Roles.cs";
    }
}
