using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AccessDenied : TemplateBase
    {
        public AccessDenied(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\GeneratorAccount\\AccessDenied.cshtml";
    }
}
