﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ValidationScriptsPartial : TemplateBase
    {
        public ValidationScriptsPartial(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "Views\\Shared\\_ValidationScriptsPartial.cshtml";
    }
}
