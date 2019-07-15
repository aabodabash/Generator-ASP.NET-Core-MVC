using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class TokensTemplate : TemplateBase
    {
        public TokensTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Helpers\\Tokens.cs";
    }
}
