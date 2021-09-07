# Phasmophobia Evidence Tracker API

## Getting Started

1. Download project
2. Run `dotnet restore`
3. Run `dotnet run`
4. Navigate to `http://localhost:5000/swagger/` to view Swagger Documentation

~~You can run the database migrations via Visual Studio in the powershell thingy running `Update-Database`. It doesn't work in vanilla powershell for some reason idk.~~

See [Running Migrations](#running-migrations) :)

## Running Migrations

0. `dotnet tool install --global dotnet-ef` to install the ef thingy
1. `dotnet ef migrations add [name]`
2. `dotnet ef database update`

## Code gen

Run the following

```
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

then

`dotnet aspnet-codegenerator controller -name [ControllerClass] -async -api -m [ModelClass] -dc [ContextClass] -outDir Controllers`

## To-do

- [] Add ReactJS client
- [] Add authorization
- [] Fix DB relationships (wtf)
- [] Make code good lmao


```javascript
{
  "name": "Phantom",
  "description": "A phantom ghost can possess the living, and most commonly summoned through an Ouija Board. It also includes fear into those around it.",
  "strengths": "If you look at a phantom directly your sanity will drop faster.",
  "weaknesses": "You can take a picture of the phantom to make it disappear.",
  "evidenceIds": [
    1,2,3
  ]
}
```