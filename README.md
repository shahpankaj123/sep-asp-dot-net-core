# Project Setup Guide

This project is an ASP.NET Core Web API with Entity Framework Core and MySQL.

## 1. Prerequisites

Make sure you have the following installed:

- .NET SDK 10.0 or later
- MySQL server running locally
- Git

## 2. Restore packages

From the project root, run:

```bash
dotnet restore
```

## 3. Install EF Core global tool

If you do not already have the EF Core CLI installed globally, run:

```bash
dotnet tool install --global dotnet-ef
```

If you already installed it earlier, update it with:

```bash
dotnet tool update --global dotnet-ef
```

## 4. Configure the database

This app expects a MySQL connection string in [appsettings.json](appsettings.json).

Update the connection string if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=todo_db;user=root;password=YOUR_PASSWORD"
}
```

Make sure your MySQL server is running and the database exists or EF can create it.

## 5. Create and apply migrations

Generate a migration:

```bash
dotnet ef migrations add InitialMigration
```

Apply the migration:

```bash
dotnet ef database update
```

## 6. Run the project

Start the API:

```bash
dotnet run
```

The app will start and listen on the default ASP.NET Core URLs.

## 7. Useful commands

- Rebuild:

```bash
dotnet build
```

- Remove the last migration:

```bash
dotnet ef migrations remove
```

- View pending migrations:

```bash
dotnet ef migrations list
```

## 8. Troubleshooting

If you see a package restore or EF CLI issue, try:

```bash
dotnet --info
dotnet clean
dotnet restore
```

If the EF tool is not recognized, restart your terminal or add the .NET tools path to your PATH.
