using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class LoginPartial : TemplateBase
    {
        public LoginPartial(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_LoginPartial.cshtml";
    }
}
