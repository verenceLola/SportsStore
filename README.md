# SportsStore

This is a C# Practice Project for ASP.NET Core MVC.

## How to run the application

To run the application, use `Visual Studio` to run and buld the project. To run using the DOtnet CLI, run the following command

```bash
dotnet run --project src/SportsStore/SportsStore.csproj
```

To run the application in development mode for auto refresh; use the following command

```bash
dotnet watch --project src/SportStore/SportsStore.csproj run
```

To run the application unit tests, run the following command or use `Visual Studio` xUnit panel to run the tests

```bash
dotnet test --project tests/SportsStore.Tests/SportsStore.Tests.csproj
```

To run the tests in development mode for auth refresh; use the foloowing command

```bash
dotnet watch --project src/SportsStore.Tests/SportsStore.Tests.csproj test
```

## Hot to run and apply application migrations

Ensure that you have `dotnet ef` install or run the following command;

```bash
dotnet tool install --global dotnet-ef
```

To run application migrations; run the following command

```bash
dotnet ef migrations add src/SportsStore/SportsStore.csproj <NAME_OF_MIGRATION>
```

Ensure you update the database after running migrations if needed by running
;

```bash
dotnet ef database update src/SportsStore/SportsStore.csproj
```

### How to install packages or add reference

To install new packages in to the application; use the foloowing command

```bash
dotnet add src/SportsStore/SportsStore.csproj package --version <PACKAGE_VERSION>
```

To add references to the application; run the following command

```bash
dotnet add src/SportsStore/SportsStore.csproj reference
```
