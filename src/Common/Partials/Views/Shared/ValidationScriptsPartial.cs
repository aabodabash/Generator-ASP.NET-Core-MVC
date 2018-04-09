using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 49)]
    public partial class ValidationScriptsPartial : TemplateBase
    {
        public ValidationScriptsPartial(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_ValidationScriptsPartial.cshtml";
    }
}
