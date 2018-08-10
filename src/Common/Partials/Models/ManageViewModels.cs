using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageViewModels : TemplateBase
    {
        public ManageViewModels(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\ManageViewModels.cs";
    }
}
