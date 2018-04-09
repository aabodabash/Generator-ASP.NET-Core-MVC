using Mobioos.Scaffold.Core.Runtime.Activities;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using Mobioos.Foundation.Prompts.Interfaces;
using System.Collections.Generic;
using Mobioos.Foundation.Prompts;
using Mobioos.Foundation.Jade.Models;

namespace Mobioos.Generators.AspNetCore
{
    [Activity(Order = 1)]
    public class CommonActivity : GeneratorActivity
    {
        public CommonActivity(string name, string basePath)
            : base(name, basePath)
        {

        }

        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            await base.Initializing(activityContext);
        }

        [Task(Order = 2)]
        public async override Task Writing()
        {
            Context.RuntimeContext.Runtime.Logger.Info($"writing aspnet core common activity for session: { Context.RuntimeContext.Runtime.SessionId.ToString()}");
            if (null == Context.DynamicContext.Manifest)
                throw new ArgumentNullException(nameof(Context.DynamicContext.Manifest));

            var executingAssembly = Assembly.GetExecutingAssembly();

            var success = ExecuteTemplates("CommonActivity", BasePath, Context.DynamicContext.Manifest, executingAssembly);
            if (success)
            {
                success = CopyDirectory(Path.Combine(Context.DynamicContext.GeneratorPath, "Platforms\\Backend\\AspNetCore\\Common\\Templates"), BasePath);
            }

            TransformAppSettings(Context.DynamicContext.Manifest);

            await base.Writing();
        }

        private void TransformAppSettings(SmartAppInfo manifest)
        {
            var authenticationKeys = Context.DynamicContext.AuthenticationKeys as Dictionary<string, string>;
            var template = new AppSettingsTemplate(manifest, authenticationKeys);
            WriteFile(Path.Combine(BasePath, template.OutputPath), template.TransformText());
            CopyFile(Path.Combine(BasePath, template.OutputPath), Path.Combine(BasePath, "appsettings.Development.json"));
        }
    }
}
