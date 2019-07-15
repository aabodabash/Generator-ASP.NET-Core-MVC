using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;
using System;

namespace Mobioos.Generators.AspNetCore
{
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
