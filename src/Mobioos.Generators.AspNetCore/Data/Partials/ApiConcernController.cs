using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ApiConcernController : TemplateBase
    {
        public IDictionary<string, string> ReferencedTypes { get; set; }

        public ApiConcernController(
            LayoutInfo model,
            string applicationId,
            string version,
            IDictionary<string, string> referencedTypes)
            : base(model, applicationId, version)
        {
            ReferencedTypes = referencedTypes;
        }

        public override string OutputPath => "Api";
    }
}
