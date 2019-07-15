using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class MessageServices : TemplateBase
    {
        public MessageServices(SmartAppInfo model) : base(model)
        {
        }


        public override string OutputPath => "Services\\MessageServices.cs";
    }
}
