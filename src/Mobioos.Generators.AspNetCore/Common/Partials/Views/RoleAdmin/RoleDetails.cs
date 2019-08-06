using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RoleDetails : TemplateBase
    {
        public RoleDetails(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Views\\GeneratorRoleAdmin\\Details.cshtml";
    }
}
