using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 50)]
    public partial class ViewImports : TemplateBase
    {
        public ViewImports(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\_ViewImports.cshtml";
    }
}
