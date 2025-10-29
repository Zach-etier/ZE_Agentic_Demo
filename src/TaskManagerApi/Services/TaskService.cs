using TaskManagerApi.Models;
using TaskStatus = TaskManagerApi.Models.TaskStatus;

namespace TaskManagerApi.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskService()
    {
        // Seed with some sample data
        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Setup project",
            Description = "Initialize the task manager API",
            Status = TaskStatus.Completed,
            CompletedAt = DateTime.UtcNow.AddDays(-2)
        });

        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Create API endpoints",
            Description = "Build CRUD endpoints for tasks",
            Status = TaskStatus.InProgress,
            Priority = 2
        });

        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = "Add authentication",
            Description = "Implement user authentication",
            Status = TaskStatus.Todo,
            Priority = 1
        });
    }

    public IEnumerable<TaskItem> GetAllTasks()
    {
        return _tasks;
    }

    public TaskItem? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem CreateTask(TaskItem task)
    {
        task.Id = _nextId++;
        task.CreatedAt = DateTime.UtcNow;
        _tasks.Add(task);
        return task;
    }

    public TaskItem? UpdateTask(int id, TaskItem updatedTask)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return null;

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.Status = updatedTask.Status;
        task.Priority = updatedTask.Priority;

        // BUG: Not setting CompletedAt when status changes to Completed

        return task;
    }

    public bool DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        _tasks.Remove(task);
        return true;
    }

    // Missing: GetTasksByStatus method
    // Missing: GetTasksByPriority method
    // Missing: Search tasks by title/description
}
