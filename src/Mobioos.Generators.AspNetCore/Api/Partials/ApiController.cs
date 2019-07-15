using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiController : TemplateBase
    {
        public ApiController(ApiInfo model, string applicationId, string version, IDictionary<string, string> entities) :
            base(model, applicationId, version)
        {
            Entities = entities;
        }

        public IDictionary<string, string> Entities { get; set; }

        public override string OutputPath => "Api";
    }
}
