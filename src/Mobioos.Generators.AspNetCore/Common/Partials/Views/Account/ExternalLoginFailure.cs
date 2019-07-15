using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ExternalLoginFailure : TemplateBase
    {
        public ExternalLoginFailure(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ExternalLoginFailure.cshtml";
    }
}
