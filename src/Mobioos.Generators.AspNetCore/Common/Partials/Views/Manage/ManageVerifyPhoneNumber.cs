using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageVerifyPhoneNumber : TemplateBase
    {
        public ManageVerifyPhoneNumber(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Manage\\VerifyPhoneNumber";
    }
}
