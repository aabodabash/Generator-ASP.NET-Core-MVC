using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageChangePassword : TemplateBase
    {
        public ManageChangePassword(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Manage\\ChangePassword.cshtml";
    }
}
