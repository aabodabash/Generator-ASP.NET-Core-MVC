using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ResetPasswordConfirmation : TemplateBase
    {
        public ResetPasswordConfirmation(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\GeneratorAccount\\ResetPasswordConfirmation.cshtml";
    }
}
