## Common Activity
This activity is responsible for the generation of all default classes and assets related to an aspnet core web application, the main output of the common activity is the following classes and assets:

          * A csproj with the name of the application defined on the Manifest.
          * Program class the main application entry. 
          * Startup and Startup.Auth classes to initialize the application and the security configuration.
          * appsettings.json file for configuration.
          * Default aspnet core views, controllers and viewmodels.
          * User management views, controllers and viewmodels.
          * Generic entity framework core repository.
          * Common services (MessageService)

You can see on the below screenshot all the templates defined on the common activity:

![](https://github.com/Mobioos/ASP.NET-Core-MVC/blob/master/ScreenShots/common-activity.png)

For each template we define a partial class on the partials folder. Partial classes are used to define the model and the parameters passed by Scaffold orchestrator to the T4 templates.

### Startup template

First we need to include the base template where we define all the common using references

`<#@ include file="..\..\Base\Templates\Include.tt" #>`

After that we need to get a reference to the template model, in this case it's the Manifest model:

`<# var model = (SmartAppInfo)Model; #>`

The next step is to write the text that we want to generate, in our case it's a CSharp class, so we write first:

The using references:

`using <#= model.Id #>.Backend.Models;`

The namespace prefixed by the application identifier:

`namespace <#= model.Id #>.Backend`

After that the body of the class:

` public partial class Startup
  {
    //body of the class
  }`

We do the same for all the common templates, we write the template corresponding to the asset we want and we use the template model as parameter.

### Executing the templates

The templates are executed by the CommonActivity class, following the defined tasks.

   1. Initializing the activity with the session context:
      ```c#
        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            await base.Initializing(activityContext);
        }
      ```
   2. Executing the T4 templates and writing files to the output folder:
      ```c#
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
      ```

In the above method, we use the ExecuteTemplates helper method to get and execute all the templates related to the common activity.

We use also the CopyDirectory helper method to copy all static assets to the corresponding output folder.

To get more detail on the common activity, please check the [generator source code](https://github.com/Mobioos/ASP.NET-Core-MVC)
