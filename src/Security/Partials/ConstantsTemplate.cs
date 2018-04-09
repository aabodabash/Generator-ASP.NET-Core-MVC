using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(AuthProvidersActivity), Order = 8)]
    public partial class ConstantsTemplate : TemplateBase
    {
        public ConstantsTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Helpers\\Constants.cs";
    }
}
