using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System.Collections.Generic;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ViewModelTemplate : TemplateBase
    {
        public string ViewModelNamespace { get; set; }
        public IDictionary<string, string> ModelPropertiesTypes { get; set; }

        public ViewModelTemplate(
            EntityInfo model,
            string applicationId,
            string viewModelNamespace,
            IDictionary<string, string> modelPropertiesTypes)
            : base(model, applicationId)
        {
            ViewModelNamespace = viewModelNamespace;
            ModelPropertiesTypes = modelPropertiesTypes;
        }

        public override string OutputPath => "ViewModels";
    }
}
