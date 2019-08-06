using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RoleDelete : TemplateBase
    {
        public RoleDelete(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Views\\GeneratorRoleAdmin\\Delete.cshtml";
    }
}
