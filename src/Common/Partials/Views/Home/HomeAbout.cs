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
    [Generator(ActivityName = nameof(CommonActivity), Order = 31)]
    public partial class HomeAbout : TemplateBase
    {
        public HomeAbout(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Home\\About.cshtml";
    }
}
