using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 5)]
    public partial class ControllerBase : TemplateBase
    {
        public ControllerBase(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Controllers\\ControllerBase.cs";
    }
}
