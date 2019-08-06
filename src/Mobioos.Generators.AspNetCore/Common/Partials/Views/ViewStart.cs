using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ViewStart : TemplateBase
    {
        public ViewStart(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Views\\_ViewStart.cshtml";
    }
}
