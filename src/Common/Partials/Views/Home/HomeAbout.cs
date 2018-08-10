using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class HomeAbout : TemplateBase
    {
        public HomeAbout(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Home\\About.cshtml";
    }
}
