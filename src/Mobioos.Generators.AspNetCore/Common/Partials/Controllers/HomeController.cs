using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class HomeController : TemplateBase
    {
        public HomeController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\HomeController.cs";
    }
}
