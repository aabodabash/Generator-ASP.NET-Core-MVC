using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 3)]
    public partial class ProgramTemplate : TemplateBase
    {
        public ProgramTemplate(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Program.cs";
    }
}
