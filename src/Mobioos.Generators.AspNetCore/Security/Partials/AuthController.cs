using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AuthController : TemplateBase
    {
        public AuthController(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\AuthController.cs";
    }
}
