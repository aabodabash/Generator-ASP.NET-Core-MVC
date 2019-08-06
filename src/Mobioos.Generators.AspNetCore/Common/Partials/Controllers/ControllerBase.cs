using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ControllerBase : TemplateBase
    {
        public ControllerBase(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Controllers\\ControllerBase.cs";
    }
}
