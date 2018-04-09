using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(AuthProvidersActivity), Order = 4)]
    public partial class FacebookAuthViewModel : TemplateBase
    {
        public FacebookAuthViewModel(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "ViewModels\\FacebookAuthViewModel.cs";
    }
}
