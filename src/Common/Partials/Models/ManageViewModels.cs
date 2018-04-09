using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 14)]
    public partial class ManageViewModels : TemplateBase
    {
        public ManageViewModels(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\ManageViewModels.cs";
    }
}
