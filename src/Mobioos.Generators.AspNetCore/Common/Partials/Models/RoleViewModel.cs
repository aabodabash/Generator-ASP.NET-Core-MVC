using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RoleViewModel : TemplateBase
    {
        public RoleViewModel(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Models\\RoleViewModel.cs";
    }
}
