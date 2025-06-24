# Gateway

## Project Structure

- `Gateway.Domain` – Domain entities, value objects, and core business logic
- `Gateway.Application` – Application services, use cases, background workers
- `Gateway.Infrastructure` – Persistence, UDP server, cloud integration
- `Gateway` – ASP.NET Core host (entry point, DI, configuration)

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/)

### Build and Run

```sh
dotnet build
dotnet run --project src/Gateway/Gateway.csproj
```

## Entity Framework Core

This project uses [Entity Framework Core](https://docs.microsoft.com/ef/core/) for data access and migrations.

### Applying Migrations

To apply the latest migrations and update the database, run:

```sh
dotnet ef database update --project src/Gateway.Infrastructure --startup-project src/Gateway
```

Make sure you have the [dotnet-ef](https://docs.microsoft.com/ef/core/cli/dotnet) tool installed:

```sh
dotnet tool install --global dotnet-ef
```

The gateway uses SQLite (`gw.db` in the `src/Gateway` directory).  
Entity Framework Core migrations are used for schema management.
