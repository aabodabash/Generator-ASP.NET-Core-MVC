using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiController : TemplateBase
    {
        public List<string> Entities { get; set; }

        public ApiController(
            ApiInfo model,
            string applicationId,
            string version,
            List<string> entities)
            : base(model, applicationId, version)
        {
            Entities = entities;
        }

        public override string OutputPath => "Api";
    }
}
