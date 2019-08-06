using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class JwtIssuerOptions : TemplateBase
    {
        public JwtIssuerOptions(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Auth\\JwtIssuerOptions.cs";
    }
}
