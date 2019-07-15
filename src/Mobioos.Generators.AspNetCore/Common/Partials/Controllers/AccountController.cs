using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AccountController : TemplateBase
    {
        public AccountController(SmartAppInfo model) : base(model)
        {
        }


        public override string OutputPath => "Controllers\\AccountController.cs";
    }
}
