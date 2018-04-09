using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 18)]
    public partial class AccessDenied : TemplateBase
    {
        public AccessDenied(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\AccessDenied.cshtml";
    }
}
