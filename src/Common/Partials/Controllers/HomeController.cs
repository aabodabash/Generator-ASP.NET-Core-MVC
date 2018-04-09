using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 6)]
    public partial class HomeController : TemplateBase
    {
        public HomeController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\HomeController.cs";
    }
}
