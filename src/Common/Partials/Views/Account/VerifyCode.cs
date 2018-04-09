using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 30)]
    public partial class VerifyCode : TemplateBase
    {
        public VerifyCode(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\VerifyCode.cshtml";
    }
}
