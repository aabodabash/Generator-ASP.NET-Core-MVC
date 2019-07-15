using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class Startup : TemplateBase
    {
        public Startup(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Startup.cs";
    }
}
