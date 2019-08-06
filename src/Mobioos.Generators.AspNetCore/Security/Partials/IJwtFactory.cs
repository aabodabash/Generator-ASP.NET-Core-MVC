using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class IJwtFactory : TemplateBase
    {
        public IJwtFactory(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Auth\\IJwtFactory.cs";
    }
}
