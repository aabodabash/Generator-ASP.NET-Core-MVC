using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class GeneratorManageController : TemplateBase
    {
        public GeneratorManageController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\GeneratorManageController.cs";
    }
}
