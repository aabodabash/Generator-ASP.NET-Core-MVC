﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class ServiceTemplate : TemplateBase
    {
        public ServiceTemplate(EntityInfo model, string applicationId, string version) :
            base(model, applicationId, version)
        {
        }

        public override string OutputPath => "Services";
    }
}
