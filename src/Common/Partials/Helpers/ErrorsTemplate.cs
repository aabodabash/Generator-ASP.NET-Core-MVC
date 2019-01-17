using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ErrorsTemplate : TemplateBase
    {
        public ErrorsTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Helpers\\Errors.cs";
    }
}
