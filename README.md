# Dotnet Centralised Package Management
Dependency management is an important requirement in any .NET app. Managing dependencies for a single project can be easy. Managing dependencies for multi-project solutions can prove to be difficult as they start to scale in size and complexity.

## What's the motivation?
Have you ever used an external NuGet package in your application and overtime, the same package was required to be injected into multiple project files?

To top it off, after a few weeks, you see your package manager flagging a direct or a transitive vulnerability in one of those packages. 
And you're out there manually updating the same package to the latest version in multiple individual project files? 
There clearly is a problem here wherein a lot of potentially `similar` project settings, package references etc. are `repeated` in each project within a solution.

I myself was in the same situation a few weeks back and I thought to myself, is there a better way to deal with it? 

## Enter Central Package Management
Starting with NuGet 6.2, you can centrally manage your dependencies in your projects with the addition of a `Directory.Packages.props` file and an MSBuild property namely `ManagePackageVersionsCentrally`.
The solution described here is a two-fold solution. Let us start with understanding the significance of `Directory.Build.props`

### Using `Directory.Build.props`
A `Directory.Build.props` file can reside in the root directory of your .NET project and contain properties that will get applied to **every** project in the solution. It is useful for enforcing project standards in one spot without needing to configure each project.

Once the settings are placed in `Directory.Build.props` file, we can omit the same files in all the individual projects in the solution thus ensuring a clean, consistent and optimal implementation across all the projects within same solution

```xml
<!-- Sample Directory.Build.props file -->
<Project>
    <PropertyGroup>
        <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
        <TargetFramework>net8.0</TargetFramework>
        <ImplicitUsings>true</ImplicitUsings>
        <Nullable>enable</Nullable>
        <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
        <LangVersion>latest</LangVersion>
    </PropertyGroup>
</Project>
```
Now that we understand the importance of `Directory.Build.props` file, let's get back to streamlining the version of the dependencies (packages) in our solution.

### Using `Directory.Packages.props`
Within the`Directory.Packages.props` file we could all the packages along with their versions that are required to be used in any of the project. 
Think of it as one big container where you're specifying specific version of the packages instructing .NET to use the specified version of the package if/when the package is used in the individual projects.

It is important to note that here, we are required to use `PackageVersion` and not `PackageReference`

```xml
<!-- Sample Directory.Packages.props file -->
<Project>
  <ItemGroup>
	<PackageVersion Include="Newtonsoft.Json" Version="13.0.3" />
  </ItemGroup>
</Project>
```

Once this file is added, our updated sample project file would look like this.
```xml
<!-- Sample .csproj file -->
<Project>
  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>
  <ItemGroup>
     <!-- The exact version of the Newtonsoft.Json's dependency would be taken from Directory.Packages.props file -->
    <PackageReference Include="Newtonsoft.Json" />
  </ItemGroup>
</Project>
```
## Show me the Code :)

- `WithoutCPM` - This is how a normal solution/project structure looks like.
- `WithCPM` - This folder has central package management solution implemented. 

As you can see, this is clearly a more streamlined implementation promoting reusable, cleaner and a robust way to handle package management in your .NET Apps

## References
- https://learn.microsoft.com/en-us/nuget/consume-packages/Central-Package-Management
- https://devblogs.microsoft.com/nuget/introducing-central-package-management/
- https://github.com/ardalis/CleanArchitecture

## Give a Star! ⭐
Feel free to request an issue on github if you find bugs or request a new feature. Your valuable feedback is much appreciated to better improve this project. If you find this useful, please give it a star to show your support for this project.


