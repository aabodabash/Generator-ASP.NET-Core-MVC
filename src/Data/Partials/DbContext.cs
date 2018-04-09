﻿using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(DataActivity), Order = 2)]
    public partial class DbContext : TemplateBase
    {
        public DbContext(SmartAppInfo model) : base(model)
        {

        }

        public override string OutputPath => "Models\\ApplicationDbContext.cs";
    }
}
