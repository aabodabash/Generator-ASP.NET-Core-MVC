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
    [Generator(ActivityName = nameof(CommonActivity), Order = 36)]
    public partial class ManageChangePassword : TemplateBase
    {
        public ManageChangePassword(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Manage\\ChangePassword.cshtml";
    }
}
