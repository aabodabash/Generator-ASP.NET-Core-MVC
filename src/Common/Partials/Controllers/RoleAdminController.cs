using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RoleAdminController : TemplateBase
    {
        public RoleAdminController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\RoleAdminController.cs";
    }
}
