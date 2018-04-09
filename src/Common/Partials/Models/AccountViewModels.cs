using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 11)]
    public partial class AccountViewModels : TemplateBase
    {
        public AccountViewModels(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\AccountViewModels.cs";
    }
}
