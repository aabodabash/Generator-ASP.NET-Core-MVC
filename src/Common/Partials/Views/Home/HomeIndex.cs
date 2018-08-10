using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class HomeIndex : TemplateBase
    {
        public HomeIndex(SmartAppInfo model): base(model)
        {

        }

        public override string OutputPath => "Views\\Home\\Index.cshtml";
    }
}
