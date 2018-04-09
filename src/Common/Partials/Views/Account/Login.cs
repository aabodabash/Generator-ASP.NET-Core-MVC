using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 25)]
    public partial class Login : TemplateBase
    {
        public Login(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\Login.cshtml";
    }
}
