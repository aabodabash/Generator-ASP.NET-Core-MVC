using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class GeneratorHomeController : TemplateBase
    {
        public GeneratorHomeController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\GeneratorHomeController.cs";
    }
}
