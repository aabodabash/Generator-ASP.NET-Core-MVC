using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 32)]
    public partial class HomeContact : TemplateBase
    {
        public HomeContact(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Home\\Contact.cshtml";
    }
}
