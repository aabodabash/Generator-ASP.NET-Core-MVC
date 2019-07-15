using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiGetAllTemplate : TemplateBase
    {
        public ApiGetAllTemplate(ApiActionInfo model, IDictionary<string, string> entities) :
            base(model)
        {
            Entities = entities;
        }

        public IDictionary<string, string> Entities { get; set; }
    }
}
