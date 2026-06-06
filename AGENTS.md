# AGENTS.md

This file is the working guide for AI agents and contributors touching the SupportHub MVC project. Keep it current as the project grows.

## Project Overview

- Solution: `SupportHub.Mvc.sln`
- Web app: `SupportHub.Mvc/SupportHub.Mvc.csproj`
- Framework: ASP.NET Core MVC targeting `net10.0`
- Language settings: nullable reference types and implicit usings are enabled.
- UI stack: Razor views, Bootstrap, jQuery, and static assets under `SupportHub.Mvc/wwwroot`.

## Repository Layout

- `SupportHub.Mvc/Program.cs`: application startup, middleware, endpoint routing, and service registration.
- `SupportHub.Mvc/Controllers`: MVC controllers. Keep actions thin and move business rules into services as the app grows.
- `SupportHub.Mvc/Models`: view models and simple MVC models. Prefer explicit view models over passing domain entities directly to views.
- `SupportHub.Mvc/Views`: Razor views grouped by controller plus shared layout and partials.
- `SupportHub.Mvc/wwwroot`: static CSS, JavaScript, images, and client libraries.
- `SupportHub.Mvc/appsettings.json`: non-secret configuration defaults.
- `SupportHub.Mvc/Properties/launchSettings.json`: local development launch profiles.

## Common Commands

Run commands from the repository root unless noted otherwise.

```powershell
dotnet restore SupportHub.Mvc.sln
dotnet build SupportHub.Mvc.sln
dotnet run --project SupportHub.Mvc\SupportHub.Mvc.csproj
dotnet watch --project SupportHub.Mvc\SupportHub.Mvc.csproj
```

When tests are added, prefer solution-level execution:

```powershell
dotnet test SupportHub.Mvc.sln
```

## Coding Guidelines

- Follow the existing ASP.NET Core MVC conventions unless a new pattern is clearly needed.
- Keep controllers focused on HTTP flow: validate input, call application services, choose the response.
- Put reusable business logic in services registered from `Program.cs` or extension methods when registrations become noisy.
- Use async controller actions and service methods for I/O such as database, API, file, or network work.
- Keep nullable annotations meaningful. Avoid suppressing warnings unless the invariant is obvious and documented by the code.
- Prefer dependency injection over static helpers for application behavior.
- Keep public-facing strings and validation messages easy to localize later.
- Do not commit secrets, connection strings, API keys, or environment-specific credentials. Use user secrets, environment variables, or deployment configuration.

## MVC And Razor Guidelines

- Use strongly typed view models for pages with meaningful state.
- Keep Razor files mostly presentational. Move formatting, filtering, and decision-heavy logic out of views.
- Use partial views or view components for repeated UI blocks.
- Keep `_Layout.cshtml` focused on global shell concerns: metadata, navigation, scripts, and styles.
- Use tag helpers consistently for links, forms, validation, and static asset versioning.
- Preserve accessibility basics: semantic headings, labels for inputs, keyboard-friendly controls, and descriptive button/link text.

## Frontend Guidelines

- Prefer Bootstrap utilities and existing site styles before adding custom CSS.
- Put app-specific styles in `wwwroot/css/site.css` or scoped CSS files when appropriate.
- Put app-specific JavaScript in `wwwroot/js/site.js` or a focused module as the client surface grows.
- Keep client-side behavior progressive: server-rendered pages should remain understandable without JavaScript where practical.
- Do not edit files under `wwwroot/lib` manually. Update client dependencies through the chosen package/library workflow once one is established.

## Configuration And Environments

- Keep `appsettings.json` safe to commit.
- Add environment-specific overrides through `appsettings.Development.json`, user secrets, environment variables, or deployment configuration.
- If new options are introduced, bind them to typed options classes and validate required settings at startup where useful.
- Keep launch profiles local-development friendly, but avoid encoding machine-specific assumptions.

## Testing Expectations

- Add or update tests when changing non-trivial behavior.
- Prefer focused unit tests for services and integration tests for routing, filters, authentication, persistence, and full MVC flows.
- When UI behavior changes, verify the page manually in a browser and consider adding automated coverage once a browser test framework is introduced.
- Before handing work back, run at least `dotnet build SupportHub.Mvc.sln`; run `dotnet test SupportHub.Mvc.sln` when test projects exist.

## Future Architecture Notes

As SupportHub grows, keep boundaries clear:

- `Controllers`: HTTP concerns only.
- `Services` or `Application`: use cases and orchestration.
- `Domain`: business entities and rules if the domain becomes rich enough to justify it.
- `Infrastructure`: database, external APIs, email, storage, queues, and other adapters.
- `ViewModels`: page-specific request and response models for Razor views.

Avoid introducing these folders prematurely. Add them when there is real behavior to hold.

## Database And External Integrations

- If Entity Framework Core is added, keep `DbContext` and migrations in a predictable infrastructure area.
- Do not let Razor views or controllers directly own data-access details.
- Wrap external systems behind interfaces so they can be tested and swapped.
- Add timeouts, cancellation token support, logging, and safe error handling for network calls.

## Git And Change Hygiene

- Check the working tree before editing and do not overwrite unrelated user changes.
- Keep changes scoped to the requested task.
- Avoid broad formatting-only churn unless formatting is the task.
- Use clear commit messages that describe the behavior or project guidance changed.

## Agent Workflow

1. Read nearby files before changing code.
2. Prefer existing patterns over new abstractions.
3. Make the smallest change that solves the problem cleanly.
4. Run relevant build/tests when feasible.
5. Summarize what changed, what was verified, and any remaining risk.

