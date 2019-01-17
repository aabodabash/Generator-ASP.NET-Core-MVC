using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class SmsSender : TemplateBase
    {
        public SmsSender(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Infrastructure\\Services\\ISmsSender.cs";
    }
}
