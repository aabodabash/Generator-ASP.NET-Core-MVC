using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AuthSettings : TemplateBase
    {
        public AuthSettings(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Auth\\AuthSettings.cs";
    }
}
