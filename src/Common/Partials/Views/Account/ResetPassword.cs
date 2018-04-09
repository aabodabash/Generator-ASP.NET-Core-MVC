using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 27)]
    public partial class ResetPassword : TemplateBase
    {
        public ResetPassword(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ResetPassword.cshtml";
    }
}
