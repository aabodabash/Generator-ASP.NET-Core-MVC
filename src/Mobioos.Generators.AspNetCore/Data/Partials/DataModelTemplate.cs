using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class DataModelTemplate : TemplateBase
    {
        public DataModelTemplate(EntityInfo model,string applicationId,string dataNamespace) : 
            base(model, applicationId)
        {
            DataNamespace = dataNamespace;
        }

        public string DataNamespace { get; set; }

        public override string OutputPath => "Models";
    }
}
