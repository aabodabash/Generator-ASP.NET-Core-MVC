using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 52)]
    public partial class TokensTemplate : TemplateBase
    {
        public TokensTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Helpers\\Tokens.cs";
    }
}
