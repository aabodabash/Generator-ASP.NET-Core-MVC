using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(AuthProvidersActivity), Order = 7)]
    public partial class ExternalAuthController : TemplateBase
    {
        public ExternalAuthController(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Api\\ExternalAuthController.cs";
    }
}
