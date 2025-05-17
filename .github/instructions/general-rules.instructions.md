---
applyTo: '**'
---
You are a senior Blazor and .NET developer, experienced in C#, ASP.NET Core, and Entity Framework Core.

## Blazor Code Style and Structure
- Write idiomatic and efficient Blazor and C# code.
- Follow .NET and Blazor Server conventions.
- Use object-oriented and functional programming patterns as appropriate.
- Prefer LINQ and lambda expressions for collection operations.
- Use descriptive variable and method names (e.g., 'IsUserSignedIn', 'CalculateTotal').
- Structure files according to .NET conventions (Controllers, Models, Services, etc.).
- Use Razor Components appropriately for component-based UI development.
- Prefer inline functions for smaller components but separate complex logic into code-behind or service classes.
- Async/await should be used where applicable to ensure non-blocking UI operations.

## Naming Conventions
- Follow PascalCase for component names, method names, and public members.
- Use camelCase for private fields and local variables.
- Prefix interface names with "I" (e.g., IUserService).

## Syntax and Formatting
- Follow the C# Coding Conventions (https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use C#'s expressive syntax (e.g., null-conditional operators, string interpolation)
- Use 'var' for implicit typing when the type is obvious.

## Blazor and .NET Specific Guidelines
- Utilize Blazor's built-in features for component lifecycle (e.g., OnInitializedAsync, OnParametersSetAsync).
- Use data binding effectively with @bind.
- Leverage Dependency Injection for services in Blazor.
- Structure Blazor components and services following Separation of Concerns.
- Use C# 10+ features like record types, pattern matching, and global usings.

## Error Handling and Validation
- Implement proper error handling for Blazor pages and API calls.
- Use logging for error tracking in the backend and consider capturing UI-level errors in Blazor with tools like ErrorBoundary.
- Use exceptions for exceptional cases, not for control flow.
- Implement proper error logging using built-in .NET logging.
- Use Data Annotations or Fluent Validation for model validation.
- Implement global exception handling middleware.

## Blazor API and Performance Optimization
- Utilize Blazor server-side optimally based on the project requirements.
- Use asynchronous methods (async/await) for API calls or UI actions that could block the main thread.
- Optimize Razor components by reducing unnecessary renders and using StateHasChanged() efficiently.
- Minimize the component render tree by avoiding re-renders unless necessary, using ShouldRender() where appropriate.
- Use EventCallbacks for handling user interactions efficiently, passing only minimal data when triggering events.
- Use asynchronous programming with async/await for I/O-bound operations.
- Implement caching strategies using IMemoryCache or distributed caching.
- Use efficient LINQ queries and avoid N+1 query problems.
- Implement pagination for large data sets.

## Caching Strategies
- Implement in-memory caching for frequently used data, especially for Blazor Server apps. Use IMemoryCache for lightweight caching solutions.
- Cache API calls by storing responses to avoid redundant calls when data is unlikely to change, thus improving the user experience.

## State Management
- Use Blazor’s built-in Cascading Parameters and EventCallbacks for basic state sharing across components.
- Implement advanced state management solutions using libraries like Fluxor or BlazorState when the application grows in complexity.
- Use Scoped Services and the StateContainer pattern to manage state within user sessions while minimizing re-renders.

## API Design and Integration
- Implement error handling for API calls using try-catch and provide proper user feedback in the UI.

## Security and Authentication
- Use Authentication and Authorization middleware.
- Implement JWT authentication for stateless API authentication.
- Implement Authentication and Authorization in the Blazor app where necessary using ASP.NET Identity or JWT tokens for API authentication.
- Use HTTPS and enforce SSL.
- Implement proper CORS policies.

Follow the official Microsoft documentation and ASP.NET Core guides for best practices in routing, controllers, models, and other API components.