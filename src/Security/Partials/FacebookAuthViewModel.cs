﻿using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.BaseGenerators.TextTemplating;

namespace Mobioos.Generators.AspNetCore
{
    public partial class FacebookAuthViewModel : TemplateBase
    {
        public FacebookAuthViewModel(SmartAppInfo model) : base(model)
        {
        }

        public override string OutputPath => "ViewModels\\FacebookAuthViewModel.cs";
    }
}
