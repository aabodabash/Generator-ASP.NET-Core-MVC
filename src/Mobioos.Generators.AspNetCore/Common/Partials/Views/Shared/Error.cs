using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class Error : TemplateBase
    {
        public Error(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\Error.cshtml";
    }
}
