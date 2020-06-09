# SongCollector

Song collection .NET Core MVC REST API with implemented JWT authorization using Azure Active Directory.

## Built With

- [.NET Core](https://docs.microsoft.com/en-us/dotnet/core/) - .NET Core is a cross-platform version of .NET for building websites, services, and console apps
- [Entity Framework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/) - Entity Framework Core is a modern object-database mapper for .NET
- [MySQL](https://www.mysql.com/) - The world's most popular open source database
- [AutoMapper](https://www.nuget.org/packages/AutoMapper/) - A convention-based object-object mapper
- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer/) - ASP.NET Core middleware that enables an application to receive an OpenID Connect bearer token

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

.NET Core 3.1

MySQL Server

Azure Active Directory

### Installing

Clone a repository:

```
git clone https://github.com/peterdotw/SongCollector.git
```

Rename .env.example file to .env and add your credentials to .env file:

```
cd SongCollector
mv .env.example .env
```

Lastly run the server:

```
dotnet run
```