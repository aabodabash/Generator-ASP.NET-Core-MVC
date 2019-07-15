using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class DesignTimeDbContextFactory : TemplateBase
    {
        public DesignTimeDbContextFactory(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "DesignTimeDbContextFactory.cs";
    }
}
