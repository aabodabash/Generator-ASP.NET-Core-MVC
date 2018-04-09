using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 24)]
    public partial class Lockout : TemplateBase
    {
        public Lockout(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\Lockout.cshtml";
    }
}
