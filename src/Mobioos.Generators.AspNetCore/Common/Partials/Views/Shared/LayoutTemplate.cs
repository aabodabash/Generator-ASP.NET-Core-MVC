using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class LayoutTemplate : TemplateBase
    {
        public LayoutTemplate(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_Layout.cshtml";
    }
}
