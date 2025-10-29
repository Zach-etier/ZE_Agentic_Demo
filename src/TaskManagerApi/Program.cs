using TaskManagerApi.Models;
using TaskManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints

app.MapGet("/", () => new
{
    Name = "Task Manager API",
    Version = "1.0.0",
    Endpoints = new[]
    {
        "GET /tasks - Get all tasks",
        "GET /tasks/{id} - Get task by ID",
        "POST /tasks - Create new task",
        "PUT /tasks/{id} - Update task",
        "DELETE /tasks/{id} - Delete task"
    }
})
.WithName("GetApiInfo")
.WithOpenApi();

app.MapGet("/tasks", (TaskService taskService) =>
{
    var tasks = taskService.GetAllTasks();
    return Results.Ok(tasks);
})
.WithName("GetAllTasks")
.WithOpenApi();

app.MapGet("/tasks/{id:int}", (int id, TaskService taskService) =>
{
    var task = taskService.GetTaskById(id);
    if (task == null)
    {
        return Results.NotFound(new { error = $"Task with ID {id} not found" });
    }
    return Results.Ok(task);
})
.WithName("GetTaskById")
.WithOpenApi();

app.MapPost("/tasks", (TaskItem task, TaskService taskService) =>
{
    // BUG: No validation on input
    var createdTask = taskService.CreateTask(task);
    return Results.Created($"/tasks/{createdTask.Id}", createdTask);
})
.WithName("CreateTask")
.WithOpenApi();

app.MapPut("/tasks/{id:int}", (int id, TaskItem task, TaskService taskService) =>
{
    var updatedTask = taskService.UpdateTask(id, task);
    if (updatedTask == null)
    {
        return Results.NotFound(new { error = $"Task with ID {id} not found" });
    }
    return Results.Ok(updatedTask);
})
.WithName("UpdateTask")
.WithOpenApi();

app.MapDelete("/tasks/{id:int}", (int id, TaskService taskService) =>
{
    var deleted = taskService.DeleteTask(id);
    if (!deleted)
    {
        return Results.NotFound(new { error = $"Task with ID {id} not found" });
    }
    return Results.NoContent();
})
.WithName("DeleteTask")
.WithOpenApi();

// Missing: Filter endpoints (by status, priority)
// Missing: Search endpoint
// Missing: Statistics endpoint

app.Run();
