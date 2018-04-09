using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 46)]
    public partial class Error : TemplateBase
    {
        public Error(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\Error.cshtml";
    }
}
