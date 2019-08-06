using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class StartupAuth : TemplateBase
    {
        public IDictionary<string, string> AuthenticationKeys { get; private set; }

        public StartupAuth(
            SmartAppInfo model,
            IDictionary<string, string> authenticationKeys)
            : base(model)
        {
            AuthenticationKeys = authenticationKeys;
        }

        public override string OutputPath => "Startup.Auth.cs";
    }
}
