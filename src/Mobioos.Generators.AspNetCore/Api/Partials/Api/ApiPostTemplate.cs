using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiPostTemplate : TemplateBase
    {
        public ApiPostTemplate(ApiActionInfo model)
            : base(model)
        {
        }
    }
}
