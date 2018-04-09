### Data Activity

The data activity is responsible for the generation of all views, controllers, entities, services and repositories classes  related to an entity defined on the manifest, the main output of the data activity is the following classes:

          * CRUD views for all non abstract classes.
          * Backoffice controllers and viewmodels for all non abstract classes.
          * Service classes for all non abstract entities.
          * Entities classes for all entities.
          * Enumerations defined on the data domain.
          * Data Repositories using entity framework dbcontext for all the non abstract entities.
          * Entity framework core DBContext.

The activity structure:

![](https://github.com/Mobioos/ASP.NET-Core-MVC/blob/master/ScreenShots/data-activity.png)

As for Common Activity, we have the templates files and the partial classes.

### Data Model template
In the DataModelTemplate we have as a parameter the EntityInfo model that defines an entity:

`<# var model = (EntityInfo)Model; #>`

We write the structure of the class with namespace, class declaration and after that we read all the properties and references of the entity to generate properties and references:

```c#
<# if (model.Properties != null) {#>
  <# foreach(var prop in model.Properties) {#>
	public <#= prop.CSharpType() #><#= prop.IsNullable? "?" : ""#> <#= prop.Id #> { get; set; }
<# } }#>
```

We do the same for the references:

``````c#
<# if(model.References !=null && model.References.Count() > 0) {
      foreach(var reference in model.References) {
        if(reference.IsCollection){ #>
		private HashSet<<#= reference.Type #>> _<#= reference.Id #>; 
		<# var currentReference = reference.Id; var referenceName = currentReference.First().ToString().ToUpper()                 + currentReference.Substring(1); #>
		<#if(reference.Target!=null && reference.Target.IsAbstract){#>
		[NotMapped]
		<#}#>
		public HashSet<<#= reference.Type #>> <#= referenceName #> { get { return _<#= reference.Id #> ??,    (_<#=reference.Id #> = new HashSet<<#= reference.Type #>>()); }}

<#}#>
``````

We use the same EntityInfo model to generate all the data classes (Views, Controllers, ViewModels, Services, Repositories).

### Executing the templates

The templates are executed by the DataActivity class, following the defined tasks.

   1. Initializing the activity with the session context:
      ```c#
        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            _sessionId = activityContext.RuntimeContext.Runtime.SessionId.ToString();

            await base.Initializing(activityContext);
        }
      ```
   2. Executing the T4 templates and writing files to the output folder:
      ```c#
        [Task(Order = 2)]
        public async override Task Writing()
        {
            bool hasError = false;

            if (null == Context.DynamicContext.Manifest)
                throw new NullReferenceException("Manifest object is null or empty");

            var sessionId = Context.RuntimeContext.Runtime.SessionId.ToString();

            try
            {
                CheckPrimaryKeys();

                var manifest = Context.DynamicContext.Manifest;

                if (ExecuteTemplates(nameof(DataActivity), BasePath, manifest, Assembly.GetExecutingAssembly()))
                {
                    if (!Directory.Exists(BasePath))
                        Directory.CreateDirectory(BasePath);

                    TransformDataModels(manifest);
                    TransformControllers(manifest);
                    TransformViews(manifest);
                }
            }
            catch (Exception e)
            {
                hasError = true;
                Context.RuntimeContext.Runtime.Logger.Error($"exception occured on data activity for session: {sessionId}, exception message: {e.Message}");
                HandleErrors(sessionId);
            }

            if (!hasError)
            {
                await base.Writing();
            }
        }
      ```

   3. The templates execution and writing are defined in multiple Transformation methods, example of the TransformEntities:
      ```c#
         private void TransformEntities(SmartAppInfo manifest)
        {
            try
            {
                var enabledEntities = manifest.DataModel.Entities.Where(e => !e.IsEnum).AsEnumerable();
                foreach (var entity in enabledEntities)
                {
                    Context.RuntimeContext.Runtime.Logger.Info($"generating entity: {entity.Id}");

                    var template = new DataModelTemplate(entity, manifest.Id, Constants.DataNamespace);
                    WriteFile(Path.Combine(BasePath, template.OutputPath, $"{entity.Id}.g.cs"), template.TransformText());

                    if (!entity.IsAbstract)
                    {
                        var key = entity.AllProperties()?.FirstOrDefault(p => p.IsKey);
                        if (key == null)
                        {
                            Context.RuntimeContext.Runtime.Logger.Warn($"Entity: {entity.Id} does not contain a primary key");
                        }
                        else
                        {
                            var irepositoryTemplate = new IDataRepository(entity, manifest.Id, Constants.Version);
                            WriteFile(Path.Combine(BasePath, irepositoryTemplate.OutputPath, $"I{entity.Id}Repository.g.cs"), irepositoryTemplate.TransformText());

                            var repositoryTemplate = new DataRepository(entity, manifest.Id, Constants.Version);
                            WriteFile(Path.Combine(BasePath, repositoryTemplate.OutputPath, $"{entity.Id}Repository.g.cs"), repositoryTemplate.TransformText());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Context.RuntimeContext.Runtime.Logger.Error($"error on generating application data model for session: {_sessionId} with exception message: {ex.Message}");
                Context.RuntimeContext.Runtime.Logger.Error($"Stacktrace: {ex.StackTrace}");
            }
        }
      ```

In the above method, we select all the entities that are not enumeration and we call the DataModelTemplate to generate the corresponding output, after that we call the Write method to save the file to the corresponding folder.

We also generate the corresponding repositories (Interface and Implementation).

To get more detail on the data activity, please check the [generator source code](https://github.com/Mobioos/ASP.NET-Core-MVC)
