using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class DataRepository : TemplateBase
    {
        public DataRepository(
            EntityInfo model,
            string applicationId,
            string version)
            : base(model, applicationId, version)
        {

        }

        public override string OutputPath => "Repositories";
    }
}
