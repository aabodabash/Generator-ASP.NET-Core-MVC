using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApplicationUser : TemplateBase
    {
        public ApplicationUser(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Models\\ApplicationUser.cs";
    }
}
