using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 20)]
    public partial class ExternalLoginConfirmation : TemplateBase
    {
        public ExternalLoginConfirmation(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ExternalLoginConfirmation.cshtml";
    }
}
