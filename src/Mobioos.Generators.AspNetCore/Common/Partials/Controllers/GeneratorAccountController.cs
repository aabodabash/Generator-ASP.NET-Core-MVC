using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class GeneratorAccountController : TemplateBase
    {
        public GeneratorAccountController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\GeneratorAccountController.cs";
    }
}
