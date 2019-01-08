# ASP .NET Core Backend Generator

## Technologies & Dependencies

<img src="https://github.com/Mobioos/ASP.NET-Core-MVC/wiki/imgs/dependencies.PNG"/>

- ASP .NET Core : 2.0
- ASP .NET Core Authentication : 2.0.1
- ASP .NET Core EntityFramework : 2.0.1
- Swagger : 1.1.0

## Generated code's architecture

- General project structure :

<img src="https://github.com/Mobioos/ASP.NET-Core-MVC/wiki/imgs/project_structure.PNG"/>

The code is generated from the modelization with the following rules :
- ViewModels are generated from the Model DSL.
- Controllers exposes methods of the API DSL.
- Services layer is empty and will encapsulate the business logic
- Repositories exposes CRUD methods on Model object
- Models are entitites that are generated from the Model DSL.

### Generated ASP .NET project's specifications
- Project architecture : MVVM
- Web services : REST
- Internationalization : Initialization based on described languages in the Forge modelization's metadatas.

## Interview's Questions

During the interview the generated wants to choose an authentication provider and ask you to provide the credential of the choosen authentication.

<img src="https://github.com/Mobioos/ASP.NET-Core-MVC/wiki/imgs/authentication_mode.PNG"/>

For now, the generator supports the following authentication providers :
- Google
- Twitter
- Facebook
- Microsoft