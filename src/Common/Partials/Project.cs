using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Jade.Models;
using System;
using Mobioos.Scaffold.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    [Generator(ActivityName = nameof(CommonActivity), Order = 2)]
    public partial class Project : TemplateBase
    {
        public Project(SmartAppInfo model) : base(model)
        {
            if (model == null || string.IsNullOrEmpty(model.Id))
                throw new NullReferenceException(nameof(model));

            UserSecret = $"{model.Id}.Backend-{Guid.NewGuid().ToString()}";
        }

        public string UserSecret { get; set; }

        public override string OutputPath => ((SmartAppInfo)Model).Id + ".csproj";
    }
}
