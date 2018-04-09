using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 16)]
    public partial class MessageServices : TemplateBase
    {
        public MessageServices(SmartAppInfo model) : base(model)
        {
        }


        public override string OutputPath => "Services\\MessageServices.cs";
    }
}
