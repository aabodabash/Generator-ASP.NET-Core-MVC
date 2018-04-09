using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class EntityMvcController: TemplateBase
    {
        public EntityMvcController(EntityInfo model, string applicationId) : base(model, applicationId)
        {
        }

        public override string OutputPath => "Controllers";
    }
}
