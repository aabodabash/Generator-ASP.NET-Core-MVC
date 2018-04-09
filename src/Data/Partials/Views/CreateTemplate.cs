using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class CreateTemplate : TemplateBase
    {
        public CreateTemplate(EntityInfo model, string applicationId) : base(model, applicationId)
        {
        }

        public override string OutputPath => "Views";
    }
}
