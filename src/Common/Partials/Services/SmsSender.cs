using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 17)]
    public partial class SmsSender : TemplateBase
    {
        public SmsSender(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Infrastructure\\Services\\ISmsSender.cs";
    }
}
