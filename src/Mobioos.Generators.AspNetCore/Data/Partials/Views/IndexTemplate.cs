using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class IndexTemplate : TemplateBase
    {
        public IndexTemplate(
            EntityInfo model,
            string applicationId)
            : base(model, applicationId)
        {

        }

        public override string OutputPath => "Views";
    }
}
