using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class AccountViewModels : TemplateBase
    {
        public AccountViewModels(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Models\\AccountViewModels.cs";
    }
}
