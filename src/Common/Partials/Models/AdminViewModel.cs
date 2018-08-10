using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AdminViewModel : TemplateBase
    {
        public AdminViewModel(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\AdminViewModel.cs";
    }
}
