using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class Login : TemplateBase
    {
        public Login(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\Login.cshtml";
    }
}
