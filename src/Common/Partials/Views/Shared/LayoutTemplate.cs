using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 47)]
    public partial class LayoutTemplate : TemplateBase
    {
        public LayoutTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_Layout.cshtml";
    }
}
