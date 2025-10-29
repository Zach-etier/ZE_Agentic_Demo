# Task Manager API

A simple task management API built with ASP.NET Core Minimal APIs for demonstrating the ZE Agentic Development workflow.

## Features

- ✅ Create, read, update, delete tasks
- ✅ Task status tracking (Todo, InProgress, Completed)
- ✅ Priority levels
- ✅ Swagger/OpenAPI documentation

## Known Issues (For Demo Purposes)

### Bugs
1. **CompletedAt not set** - When updating a task status to Completed, the CompletedAt timestamp is not set
2. **No input validation** - POST /tasks endpoint doesn't validate required fields

### Missing Features
1. **Filter by status** - No endpoint to get tasks by specific status
2. **Filter by priority** - No endpoint to get tasks by priority level
3. **Search functionality** - No way to search tasks by title or description
4. **Statistics endpoint** - No summary of task counts by status

## Running the API

```bash
cd src/TaskManagerApi
dotnet run
```

The API will be available at `http://localhost:5000`

Swagger UI: `http://localhost:5000/swagger`

## Example Usage

### Get all tasks
```bash
curl http://localhost:5000/tasks
```

### Create a task
```bash
curl -X POST http://localhost:5000/tasks \
  -H "Content-Type: application/json" \
  -d '{
    "title": "New Task",
    "description": "Task description",
    "priority": 2
  }'
```

### Update a task
```bash
curl -X PUT http://localhost:5000/tasks/1 \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Updated Task",
    "description": "Updated description",
    "status": 2,
    "priority": 1
  }'
```

## Using with ZE Workflow

This demo API is perfect for demonstrating the ZE Agentic Development workflow:

### Example 1: Fix the CompletedAt Bug
```bash
/ZE_1_Ticket thoughts "Fix bug where CompletedAt is not set when task status changes to Completed"
```

### Example 2: Add Filter by Status Feature
```bash
/ZE_1_Ticket thoughts "Add endpoint to filter tasks by status"
```

### Example 3: Add Input Validation
```bash
/ZE_1_Ticket thoughts "Add validation to POST /tasks endpoint for required fields"
```

Each ticket will flow through: Research → Plan → Execute → Verify

## Project Structure

```
src/TaskManagerApi/
├── Models/
│   └── TaskItem.cs          # Task model and status enum
├── Services/
│   └── TaskService.cs       # In-memory task management
├── Program.cs               # API endpoints and configuration
├── TaskManagerApi.csproj    # Project file
└── README.md               # This file
```
