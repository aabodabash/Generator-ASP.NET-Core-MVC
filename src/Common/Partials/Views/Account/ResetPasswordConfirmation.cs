using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 28)]
    public partial class ResetPasswordConfirmation : TemplateBase
    {
        public ResetPasswordConfirmation(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ResetPasswordConfirmation.cshtml";
    }
}
