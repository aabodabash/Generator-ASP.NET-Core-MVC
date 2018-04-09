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
    [Generator(ActivityName = nameof(CommonActivity), Order = 42)]
    public partial class RoleDelete : TemplateBase
    {
        public RoleDelete(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\RoleAdmin\\Delete.cshtml";
    }
}
