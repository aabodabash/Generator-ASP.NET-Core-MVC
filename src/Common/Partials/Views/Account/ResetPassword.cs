﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ResetPassword : TemplateBase
    {
        public ResetPassword(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Account\\ResetPassword.cshtml";
    }
}
