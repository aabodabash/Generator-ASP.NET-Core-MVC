using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiGetAllTemplate : TemplateBase
    {
        public ApiGetAllTemplate(
            ApiActionInfo model,
            string applicationId)
            : base(model, applicationId)
        {

        }
    }
}
