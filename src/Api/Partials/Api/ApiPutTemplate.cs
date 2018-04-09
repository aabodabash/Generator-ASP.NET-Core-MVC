using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiPutTemplate : TemplateBase
    {
        public ApiPutTemplate(ApiActionInfo model) :
            base(model)
        {
        }
    }
}
