using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class Register : TemplateBase
    {
        public Register(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\GeneratorAccount\\Register.cshtml";
    }
}
