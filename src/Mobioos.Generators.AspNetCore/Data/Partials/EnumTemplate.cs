using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class EnumTemplate : TemplateBase
    {
        public string DataNamespace { get; set; }

        public EnumTemplate(
            EntityInfo model,
            string applicationId,
            string dataNamespace)
            : base(model, applicationId)
        {
            DataNamespace = dataNamespace;
        }

        public override string OutputPath => "Models";
    }
}
