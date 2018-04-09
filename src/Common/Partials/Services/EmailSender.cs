using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 15)]
    public partial class EmailSender : TemplateBase
    {
        public EmailSender(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Infrastructure\\Services\\IEmailSender.cs";
    }
}
