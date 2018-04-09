using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 22)]
    public partial class ForgotPassword : TemplateBase
    {
        public ForgotPassword(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ForgotPassword.cshtml";
    }
}
