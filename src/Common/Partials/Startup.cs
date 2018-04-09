using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 1)]
    public partial class Startup : TemplateBase
    {
        public Startup(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Startup.cs";
    }
}
