using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 13)]
    public partial class ApplicationUser : TemplateBase
    {
        public ApplicationUser(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\ApplicationUser.cs";
    }
}
