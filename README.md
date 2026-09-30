# Survey Management API

A REST API for creating polls, publishing them to members, collecting votes, and reviewing results. It focuses on production concerns: dynamic permission-based authorization, background jobs, caching, rate limiting, API versioning, and health checks.

---

## Features

- **Authentication:** registration, login, JWT access tokens with refresh and revoke, email confirmation, forgot and reset password, and account lockout after repeated failed logins.
- **Permission-based authorization:**
  - A custom policy provider turns a `[HasPermission]` attribute into an authorization policy, so endpoints check permissions instead of hard-coded roles.
  - Roles are managed through the API and bundle 14 permissions such as `polls:add` and `results:read`.
- **Polls and questions:** create, update, delete, and publish polls, and manage the questions and answer options of each poll.
- **Voting:** one vote per user per poll, only while the poll is published and within its start and end dates, and all active questions must be answered.
- **Results:** per-poll votes with each voter and their answers.
- **Background jobs with Hangfire:**
  - Email confirmation and password reset emails are queued as background jobs.
  - Publishing a poll queues a notification to all members.
  - A daily recurring job sends notifications for polls that start that day.
  - The Hangfire dashboard is served at `/jobs` behind basic authentication.
- **Email:** MailKit with HTML templates for confirmation, password reset, and poll notifications.
- **Caching:** HybridCache for question lists, invalidated when questions change.
- **Rate limiting:** a global limit per IP, an IP policy for auth endpoints, a per-user policy, and a concurrency limiter, all returning `429`.
- **API versioning:** URL-based `v1` and `v2` on the polls endpoints.
- **Health checks:** SQL Server, Hangfire, and the mail provider at `/health`.
- **Logging and errors:** Serilog to rolling files and a global exception handler with ProblemDetails responses.

## Tech Stack

| Area | Technology |
|---|---|
| Framework | ASP.NET Core Web API, .NET 9 |
| Data | Entity Framework Core, SQL Server |
| Auth | ASP.NET Core Identity, JWT Bearer, custom permission policies |
| Background jobs | Hangfire with SQL Server storage |
| Email | MailKit |
| Caching | HybridCache |
| Validation and mapping | FluentValidation, Mapster |
| Logging | Serilog |
| API docs | Swagger (Swashbuckle) with API versioning |

## API Overview

38 endpoints.

| Controller | Purpose |
|---|---|
| `Auth` | Login, register, refresh and revoke token, confirm email, resend confirmation, forgot and reset password |
| `Account` | Current user profile, update info, change password |
| `Polls` | Poll CRUD, publish toggle, current polls (v1 and v2) |
| `Questions` | Questions of a poll |
| `Votes` | Start a vote (get questions) and submit a vote |
| `Results` | Poll votes |
| `Users` | User management, enable or disable, unlock |
| `Roles` | Role and permission management |

The Swagger UI is served at the root URL.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB is fine). Two databases are used: one for the app and one for Hangfire.
- An SMTP account for sending mail. [Ethereal](https://ethereal.email) works well for testing.

### Configure

Keep credentials out of source control by setting them with user secrets:

```bash
cd SurveyManagement
dotnet user-secrets set "Jwt:Key" "your-own-secret-key-at-least-32-characters"
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your connection string>"
dotnet user-secrets set "ConnectionStrings:HangfireConnection" "<your hangfire connection string>"
dotnet user-secrets set "MailSettings:Password" "<smtp password>"
dotnet user-secrets set "HangfireSettings:Username" "<dashboard user>"
dotnet user-secrets set "HangfireSettings:Password" "<dashboard password>"
```

### Run

```bash
dotnet ef database update
dotnet run
```

The migrations seed the `Admin` and `Member` roles and a default admin account (see `Abstractions/Consts/DefaultUsers.cs`). Change those credentials before any real use.

| URL | Purpose |
|---|---|
| `/` | Swagger UI |
| `/jobs` | Hangfire dashboard |
| `/health` | Health check report |

## Project Structure

```
SurveyManagement/
├── Abstractions/     Result, Error, constants for roles and permissions
├── Authentication/   JWT provider and permission authorization filters
├── Contracts/        Request and response models with validators
├── Controllers/      API endpoints
├── Health/           Mail provider health check
├── Persistence/      DbContext, configurations, migrations
├── RateLimiting/     Named rate limiter policies
├── Services/         Business logic behind service interfaces
└── Templates/        HTML email templates
```
