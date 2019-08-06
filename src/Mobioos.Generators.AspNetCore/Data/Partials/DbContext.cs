using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class DbContext : TemplateBase
    {
        public DbContext(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Models\\ApplicationDbContext.cs";
    }
}
