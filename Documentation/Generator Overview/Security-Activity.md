### Security Activity

The security activity is responsible for the generation of the Startup.Auth class which initialize all the settings to enable Oauth using Facebook, Twitter, Microsoft and Google. Thefollowing classes represent the result of the security activity:

          * Startup.Auth to initialize security configuration.
          * Oauth viewmodels
          * Service classes for all non abstract entities.
          * External authentication provider controllers.
          * Jwt helpers

The activity structure:

![](https://github.com/Mobioos/ASP.NET-Core-MVC/blob/master/ScreenShots/security-activity.png)

As for Common Activity, we have the templates files and the partial classes.

### Auth Controller template
The AuthController template has a parameter of type SmartAppInfo that defines the global informations of the appliction:

`<# var model = (SmartAppInfo)Model; #>`

The security templates generate almost predefined classes, we change only the namespace:

```c#
namespace <#= model.Id #>.Backend.Api
{
	[Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.Email, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

			var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.Email, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
			return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
```

We do the same for all the security template.

### Executing the templates

The templates are executed by the SecurityActivity class, following the defined tasks.

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
      ```

   3. The templates execution and writing are defined in multiple Transformation methods, example of the TransformAuthController:
      ```c#
         private void TransformAuthController(SmartAppInfo manifest)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var success = ExecuteTemplates("AuthProvidersActivity", BasePath, manifest, executingAssembly);
        }
      ```

In the above method, we use the ExecuteTemplate helper method to execute all the templates related to the AuthProvidersActivity.


To get more detail on the security activity, please check the [generator source code](https://github.com/Mobioos/ASP.NET-Core-MVC)
