using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AppSettingsTemplate : TemplateBase
    {
        public AppSettingsTemplate(SmartAppInfo model, IDictionary<string, string> authenticationKeys) : base(model)
        {
            AuthenticationKeys = authenticationKeys;
        }

        public IDictionary<string, string> AuthenticationKeys { get; private set; }

        public override string OutputPath => "appsettings.json";
    }
}
