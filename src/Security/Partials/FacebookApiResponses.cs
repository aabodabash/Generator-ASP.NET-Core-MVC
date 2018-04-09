using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(AuthProvidersActivity), Order = 6)]
    public partial class FacebookApiResponses : TemplateBase
    {
        public FacebookApiResponses(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Auth\\FacebookApiResponses.cs";
    }
}
