using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageIndex : TemplateBase
    {
        public ManageIndex(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Views\\GeneratorManage\\Index.cshtml";
    }
}
