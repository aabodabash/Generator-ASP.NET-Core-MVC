using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageController : TemplateBase
    {
        public ManageController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\ManageController.cs";
    }
}
