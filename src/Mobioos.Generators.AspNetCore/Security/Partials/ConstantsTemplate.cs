using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ConstantsTemplate : TemplateBase
    {
        public ConstantsTemplate(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Helpers\\Constants.cs";
    }
}
