using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class EmailSender : TemplateBase
    {
        public EmailSender(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Infrastructure\\Services\\IEmailSender.cs";
    }
}
