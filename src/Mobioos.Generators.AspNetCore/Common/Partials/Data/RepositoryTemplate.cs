using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class RepositoryTemplate : TemplateBase
    {
        public RepositoryTemplate(SmartAppInfo model)
            : base(model)
        {
        }

        public override string OutputPath => "Repositories\\Repository.cs";
    }
}
