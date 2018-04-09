using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 26)]
    public partial class Register : TemplateBase
    {
        public Register(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\Register.cshtml";
    }
}
