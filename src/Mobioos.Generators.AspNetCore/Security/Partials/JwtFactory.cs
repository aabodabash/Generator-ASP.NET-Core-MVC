using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class JwtFactory : TemplateBase
    {
        public JwtFactory(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Auth\\JwtFactory.cs";
    }
}
