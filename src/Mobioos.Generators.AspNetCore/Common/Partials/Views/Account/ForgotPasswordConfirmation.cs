using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ForgotPasswordConfirmation : TemplateBase
    {
        public ForgotPasswordConfirmation(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\GeneratorAccount\\ForgotPasswordConfirmation.cshtml";
    }
}
