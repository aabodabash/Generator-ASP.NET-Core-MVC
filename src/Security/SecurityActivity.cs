using Mobioos.Scaffold.Core.Runtime.Activities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System.Reflection;
using System.IO;
using Mobioos.Foundation.Jade.Models;
using Mobioos.Scaffold.Core.Runtime.Attributes;
using System.Dynamic;

namespace Mobioos.Generators.AspNetCore
{
    [Activity(Order = 4)]
    public class SecurityActivity : GeneratorActivity
    {
        public SecurityActivity(string name, string basePath) : base(name, basePath)
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
            if (null == Context.DynamicContext.Manifest)
                throw new ArgumentNullException(nameof(Context.DynamicContext.Manifest));

            var manifest = (Context.DynamicContext.Manifest as SmartAppInfo);

            var roles = new List<string>();

            if (IsPropertyExist(Context.DynamicContext, "SelectedRoles") && Context.DynamicContext.SelectedRoles != null)
            {
                roles = (Context.DynamicContext.SelectedRoles as List<string>);
            }

            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);
            
            TransformAuthController(manifest);
            TransformRoles(manifest, roles);
            TransformStartupAuth(manifest);

            await base.Writing();
        }

        private void TransformAuthController(SmartAppInfo manifest)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var success = ExecuteTemplates("AuthProvidersActivity", BasePath, manifest, executingAssembly);
        }

        private void TransformRoles(SmartAppInfo manifest, List<string> roles)
        {
            var template = new RolesTemplate(manifest, roles);
            WriteFile(Path.Combine(BasePath, template.OutputPath), template.TransformText());
        }

        private void TransformStartupAuth(SmartAppInfo manifest)
        {
            var authenticationKeys = Context.DynamicContext.AuthenticationKeys as Dictionary<string,string>;
            var template = new StartupAuth(manifest, authenticationKeys);
            WriteFile(Path.Combine(BasePath, template.OutputPath), template.TransformText());
        }

        public static bool IsPropertyExist(dynamic context, string name)
        {
            if (context is ExpandoObject)
                return ((IDictionary<string, object>)context).ContainsKey(name);

            return context.GetType().GetProperty(name) != null;
        }
    }
}
