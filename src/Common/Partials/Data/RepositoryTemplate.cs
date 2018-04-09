using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 10)]
    public partial class RepositoryTemplate : TemplateBase
    {
        public RepositoryTemplate(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Repositories\\Repository.cs";
    }
}
