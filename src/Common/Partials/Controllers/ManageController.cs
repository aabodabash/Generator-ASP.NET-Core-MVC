using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 7)]
    public partial class ManageController : TemplateBase
    {
        public ManageController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\ManageController.cs";
    }
}
