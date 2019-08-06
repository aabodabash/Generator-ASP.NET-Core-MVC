using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class FacebookApiResponses : TemplateBase
    {
        public FacebookApiResponses(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Auth\\FacebookApiResponses.cs";
    }
}
