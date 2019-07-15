using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ViewImports : TemplateBase
    {
        public ViewImports(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\_ViewImports.cshtml";
    }
}
