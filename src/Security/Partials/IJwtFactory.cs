using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(AuthProvidersActivity), Order = 3)]
    public partial class IJwtFactory : TemplateBase
    {
        public IJwtFactory(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Auth\\IJwtFactory.cs";
    }
}
