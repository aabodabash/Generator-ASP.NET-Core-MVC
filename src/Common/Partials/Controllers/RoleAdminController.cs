using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 8)]
    public partial class RoleAdminController : TemplateBase
    {
        public RoleAdminController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\RoleAdminController.cs";
    }
}
