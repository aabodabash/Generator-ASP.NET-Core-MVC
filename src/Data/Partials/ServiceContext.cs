using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ServiceContext: TemplateBase
    {
        public ServiceContext(SmartAppInfo model):base(model)
        {

        }

        public override string OutputPath => "Models\\MobileServiceContext.cs";
    }
}
