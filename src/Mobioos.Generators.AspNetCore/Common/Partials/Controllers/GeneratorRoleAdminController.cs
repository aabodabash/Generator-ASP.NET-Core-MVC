using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class GeneratorRoleAdminController : TemplateBase
    {
        public GeneratorRoleAdminController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\GeneratorRoleAdminController.cs";
    }
}
