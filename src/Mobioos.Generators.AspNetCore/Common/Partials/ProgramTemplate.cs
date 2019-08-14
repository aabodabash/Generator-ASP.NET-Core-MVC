﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ProgramTemplate : TemplateBase
    {
        public ProgramTemplate(SmartAppInfo model)
            : base(model)
        {

        }

        public override string OutputPath => "Program.cs";
    }
}
