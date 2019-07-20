﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ManageLogins : TemplateBase
    {
        public ManageLogins(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Views\\Manage\\ManageLogins.cshtml";
    }
}
