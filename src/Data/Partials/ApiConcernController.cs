using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    //[Generator("DataActivity", 1)]
    public partial class ApiConcernController : TemplateBase
    {
        public ApiConcernController(LayoutInfo model, string applicationId, string version, IDictionary<string, string> referencedTypes) :
            base(model, applicationId, version)
        {
            ReferencedTypes = referencedTypes;
        }

        public IDictionary<string, string> ReferencedTypes { get; set; }

        public override string OutputPath => "Api";
    }
}
