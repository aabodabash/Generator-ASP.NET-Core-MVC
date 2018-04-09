using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 23)]
    public partial class ForgotPasswordConfirmation : TemplateBase
    {
        public ForgotPasswordConfirmation(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ForgotPasswordConfirmation.cshtml";
    }
}
