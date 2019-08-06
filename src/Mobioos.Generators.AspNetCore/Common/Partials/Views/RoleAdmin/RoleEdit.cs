using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RoleEdit : TemplateBase
    {
        public RoleEdit(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Views\\GeneratorRoleAdmin\\Edit.cshtml";
    }
}
