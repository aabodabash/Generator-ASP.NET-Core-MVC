using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AppSettingsTemplate : TemplateBase
    {
        public IDictionary<string, string> AuthenticationKeys { get; private set; }

        public AppSettingsTemplate(
            SmartAppInfo model,
            IDictionary<string, string> authenticationKeys)
            : base(model)
        {
            AuthenticationKeys = authenticationKeys;
        }

        public override string OutputPath => "appsettings.json";
    }
}
