using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ExternalAuthController : TemplateBase
    {
        public ExternalAuthController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\ExternalAuthController.cs";
    }
}
