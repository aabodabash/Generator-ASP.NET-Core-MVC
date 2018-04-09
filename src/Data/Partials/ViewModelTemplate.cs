using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ViewModelTemplate : TemplateBase
    {
        public ViewModelTemplate(EntityInfo model, string applicationId, string viewModelNamespace, IDictionary<string, string> referencedTypes) :
            base(model, applicationId)
        {
            ViewModelNamespace = viewModelNamespace;
            ReferencedTypes = referencedTypes;

        }

        public string ViewModelNamespace { get; set; }

        public IDictionary<string, string> ReferencedTypes { get; set; }

        public override string OutputPath => "ViewModels";
    }
}
