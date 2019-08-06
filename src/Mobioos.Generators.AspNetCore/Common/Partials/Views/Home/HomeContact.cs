using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class HomeContact : TemplateBase
    {
        public HomeContact(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Views\\GeneratorHome\\Contact.cshtml";
    }
}
