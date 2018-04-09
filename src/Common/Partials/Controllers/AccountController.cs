using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 4)]
    public partial class AccountController : TemplateBase
    {
        public AccountController(SmartAppInfo model) : base(model)
        {
        }


        public override string OutputPath => "Controllers\\AccountController.cs";
    }
}
