using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 29)]
    public partial class SendCode : TemplateBase
    {
        public SendCode(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\SendCode.cshtml";
    }
}
