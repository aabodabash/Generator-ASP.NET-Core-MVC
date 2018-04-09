using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 9)]
    public partial class IRepositoryTemplate : TemplateBase
    {
        public IRepositoryTemplate(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Repositories\\Interfaces\\IRepository.cs";
    }
}
