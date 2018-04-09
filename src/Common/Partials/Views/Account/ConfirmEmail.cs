using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 19)]
    public partial class ConfirmEmail : TemplateBase
    {
        public ConfirmEmail(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ConfirmEmail.cshtml";
    }
}
