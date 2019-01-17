using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class IRepositoryTemplate : TemplateBase
    {
        public IRepositoryTemplate(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Repositories\\Interfaces\\IRepository.cs";
    }
}
