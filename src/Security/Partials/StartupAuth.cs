using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(SecurityActivity), Order = 1)]
    public partial class StartupAuth : TemplateBase
    {
        public StartupAuth(SmartAppInfo model, IDictionary<string, string> authenticationKeys) : base(model)
        {
            AuthenticationKeys = authenticationKeys;
        }

        public IDictionary<string, string> AuthenticationKeys { get; private set; }

        public override string OutputPath => "Startup.Auth.cs";
    }
}
