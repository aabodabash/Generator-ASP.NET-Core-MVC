using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ExternalLoginConfirmation : TemplateBase
    {
        public ExternalLoginConfirmation(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ExternalLoginConfirmation.cshtml";
    }
}
