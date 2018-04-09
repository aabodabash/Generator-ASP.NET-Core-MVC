using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 12)]
    public partial class AdminViewModel : TemplateBase
    {
        public AdminViewModel(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\AdminViewModel.cs";
    }
}
