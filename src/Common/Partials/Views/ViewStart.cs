using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 51)]
    public partial class ViewStart : TemplateBase
    {
        public ViewStart(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\_ViewStart.cshtml";
    }
}
