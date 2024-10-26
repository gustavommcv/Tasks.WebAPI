# Task Management API

This is a task management API developed in ASP.NET Core, using patterns such as DTO, repository, and services for a clean and scalable architecture. The API enables CRUD operations (Create, Read, Update, Delete) to manage tasks.

## Features

- Create new tasks
- Retrieve all tasks or a specific task by ID
- Update an existing task (supports both PUT and PATCH)
- Delete a task by ID

## Project Structure

The project follows a layered architecture, where the controller manages HTTP requests and communicates with the service layer, which interacts with the repository to handle data persistence.

- **Controllers**: Handle HTTP requests and responses to the client.
- **Services**: Implement business logic and execute CRUD operations through the repository.
- **Repositories**: Manage direct interaction with the database.
- **DTOs (Data Transfer Objects)**: Define data models for transport between layers, ensuring data security and integrity.

## Endpoints

| Method | Endpoint             | Description                                                                             |
|--------|-----------------------|-----------------------------------------------------------------------------------------|
| GET    | `/api/tasks`         | Returns all tasks.                                                                      |
| GET    | `/api/tasks/{id}`    | Returns a specific task by ID.                                                          |
| POST   | `/api/tasks`         | Creates a new task.                                                                     |
| PUT    | `/api/tasks/{id}`    | Updates an existing task by ID.                                                         |
| PATCH  | `/api/tasks/{id}`    | Partially updates a specific task.                                                      |
| DELETE | `/api/tasks/{id}`    | Deletes a task by ID.                                                                   |

## Setup and Run

1. Clone this repository.
2. Restore dependencies with `dotnet restore`.
3. Configure the database connection string in `appsettings.json`.
4. Run migrations with `dotnet ef database update`
5. Start the application with `dotnet run`.

## Code Structure

Below is an example of the `TasksController`, which defines the endpoints for managing tasks:

```csharp
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _tasksService;

    public TasksController(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks() => Ok(await _tasksService.GetAllTasks());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
        var task = await _tasksService.GetTaskByTaskId(id);
        return task == null ? NotFound() : Ok(task);
    }

    // Additional methods...
}
```

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- DTOs
- Dependency Injection
- Repository Pattern

## Next Steps
- Implement authentication and authorization.
- Add unit tests
- Introduce a caching layer to optimize frequent queries.
