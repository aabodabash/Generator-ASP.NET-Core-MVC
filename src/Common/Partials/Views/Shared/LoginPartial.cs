using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 48)]
    public partial class LoginPartial : TemplateBase
    {
        public LoginPartial(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_LoginPartial.cshtml";
    }
}
