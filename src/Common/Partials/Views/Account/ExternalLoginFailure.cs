using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 21)]
    public partial class ExternalLoginFailure : TemplateBase
    {
        public ExternalLoginFailure(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ExternalLoginFailure.cshtml";
    }
}
