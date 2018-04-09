### Api Activity

The api activity is responsible for the generation of all api controllers and parameters viewmodels classes related to an api defined on the manifest, the main output of the api activity is the following classes:

          * Api controllers with all the defined actions
          * Viewmodels corresponding to the parameters and return types defined on the api actions.

The activity structure:

![](https://github.com/Mobioos/ASP.NET-Core-MVC/blob/master/api-activity.png)

As for Common Activity, we have the templates files and the partial classes.

### Api Controller template
In the ApiController template we have as a parameter the ApiInfo model that defines an api:

`<# var model = (Api)Model; #>`

We write the structure of the class with namespace, class declaration and after that we read all the actions of the api to generate:

```c#
<#foreach(var action in actions){#>
    <#var firstParameter = action.Parameters.AsEnumerable().FirstOrDefault(); var lastParameter = action.Parameters.LastOrDefault();#>
		[<#=action.CSharpType()#>]
		[Route("<#=action.Url#>")]
    <#if(action.ReturnType != null){#>
		[ProducesResponseType(typeof(<#=action.ReturnType#>), 200)]
    <#}#>
		public async Task<IActionResult> <#=action.Id#>(<#foreach(var parameter in action.Parameters.AsEnumerable()){#><#=parameter.CSharpType()#> <#=parameter.Id #><#if (!parameter.Equals(lastParameter)){#>,<#}#><#}#>)
		{
                  <#if(action.Type?.ToLower() == "datacreate" && firstParameter != null) { var template = new ApiPostTemplate(action);#>
			<#Write(template.TransformText());#>
                  <#}else if(action.Type?.ToLower() == "dataupdate" && firstParameter != null) { var template = new ApiPutTemplate(action); #>
			<#Write(template.TransformText());#>
                  <#}else if(action.Type == "datadelete" && firstParameter != null) { var template = new ApiDeleteTemplate(action);#>
			<#Write(template.TransformText());#>
                  <#}else if(action.Type?.ToLower() == "datalist") { var template = new ApiGetAllTemplate(action, Entities);#>
			<#Write(template.TransformText());#>
                  <#}else if(action.Type?.ToLower() == "dataget") { var template = new ApiGetTemplate(action, Entities);#>
			<#Write(template.TransformText());#>
<#}#>
		}
<#}#>
```

The ApiController template references child templates for each action type(Get, GetAll ,Create,Update,Delete)

The below code show the ApiGetTemplate file:

```c#
<#@ include file="..\..\..\Base\Templates\Include.tt" #><# var action = (ApiActionInfo)Model; #>
<# var lastEntity = Entities.LastOrDefault(); #>
<# var firstParameter = action.Parameters.AsEnumerable().FirstOrDefault(); #>
<# var keyProperty = action.ReturnType?.AllProperties().FirstOrDefault(p=>p.IsKey); #>
<# var keyType = keyProperty !=null ? keyProperty.ModelProperty?.Substring(0, keyProperty.ModelProperty.IndexOf(".")) : ""; #>
<# if(string.IsNullOrEmpty(keyType)) { var reference = action.ReturnType?.AllReferences().FirstOrDefault(p=>p.Target != null && !p.Target.IsAbstract); keyType = reference?.CSharpType(); keyProperty=reference?.Target.AllProperties()?.FirstOrDefault(p=>p.IsKey);  }#>
			try
			{
<# if(action.ReturnType != null){#>
<# if(!string.IsNullOrEmpty(keyType) && firstParameter != null) {#>
				var entity = await _<#= keyType #>Service.GetById(<#=firstParameter.Id#>);
				if(entity != null)
				{
					var result = new <#= action.ReturnType.Id #>().ConvertFromModel(entity);
					return this.Ok(await Task.FromResult(result));
				}
		
				return NotFound();
<#}else{#>
				return this.Ok(await Task.FromResult(new <#= action.ReturnType.Id#>()));
<#}}else{#>
				return NotFound();
<#}#>
			}
			catch (Exception xcp)
			{
				//log exception
				return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
			}
```

### Executing the templates

The templates are executed by the ApiActivity class, following the defined tasks.

   1. Initializing the activity with the session context:
      ```c#
        [Task(Order = 1)]
        public async override Task Initializing(IActivityContext activityContext)
        {
            _sessionId = activityContext.RuntimeContext.Runtime.SessionId.ToString();

            await base.Initializing(activityContext);
        }      ```
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
                var manifest = Context.DynamicContext.Manifest;

                if (!Directory.Exists(BasePath))
                    Directory.CreateDirectory(BasePath);

                TransformControllerApi(manifest);
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

   3. The templates execution and writing are defined in multiple Transformation methods, example of the TransformControllerApi:
      ```c#
        private void TransformControllerApi(SmartAppInfo manifest)
        {
            bool result = true;
            var apiList = manifest.Api.AsEnumerable();

            if (apiList != null)
            {
                foreach (var api in apiList)
                {
                    if (!result)
                        break;

                    if (api != null)
                    {
                        _serviceTypes = new Dictionary<string, string>();

                        foreach (var action in api.Actions)
                        {
                            TransformControllerApiReturnTypes(manifest, action);
                            TransformControllerApiParameters(manifest, action);
                        }

                        var template = new ApiController(api, manifest.Id, Constants.Version, _serviceTypes);
                        try
                        {
                            result = WriteFile(Path.Combine(BasePath, template.OutputPath, Constants.Version, api.Id + ".g.cs"), template.TransformText());
                        }
                        catch (Exception ex)
                        {
                            result = false;
                            Context.RuntimeContext.Runtime.Logger.Error($"error on generating controllers api for session: {_sessionId} with exception message: {ex.Message}");
                        }
                    }
                }
            }
        }
      ```

In the above method, we select all the api defined on the Api domain and we call the corresponding templates to generate the corresponding output, after that we call the Write method to save the file to the corresponding folder.

We also generate the corresponding viewmodels for input and return types.

To get more detail on the api activity, please check the [generator source code](https://github.com/Mobioos/ASP.NET-Core-MVC)
