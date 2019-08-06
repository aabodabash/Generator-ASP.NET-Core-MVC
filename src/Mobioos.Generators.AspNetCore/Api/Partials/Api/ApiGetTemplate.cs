using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiGetTemplate : TemplateBase
    {

        public ApiGetTemplate(
            ApiActionInfo model,
            string applicationId)
            : base(model, applicationId)
        {

        }
    }
}
