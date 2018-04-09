using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class EntityApiController : TemplateBase
    {
        public EntityApiController(EntityInfo model, string applicationId, string version) : 
            base(model, applicationId, version)
        {
        }

        public override string OutputPath => "Api";
    }
}
