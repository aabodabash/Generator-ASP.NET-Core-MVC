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
    [Generator(ActivityName = nameof(CommonActivity), Order = 45)]
    public partial class RoleIndex : TemplateBase
    {
        public RoleIndex(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\RoleAdmin\\Index.cshtml";
    }
}
