using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiGetTemplate : TemplateBase
    {
        public ApiGetTemplate(ApiActionInfo model, IDictionary<string, string> entities) :
            base(model)
        {
            Entities = entities;
        }

        public IDictionary<string, string> Entities { get; set; }
    }
}
