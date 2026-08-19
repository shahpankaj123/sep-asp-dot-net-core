using data;
using models;
using dto;

namespace services;

public class TodoServicesImpl : ITodoService
{
    private readonly AppDbContext _context;

    public TodoServicesImpl(AppDbContext context)
    {
        _context = context;
    }

    public List<Todo> GetAllTodos()
    {
        return _context.Todos.ToList();
    }

    public Todo? GetTodoById(int todoId)
    {
        return _context.Todos
            .FirstOrDefault(t => t.Id == todoId);
    }

    public bool CreateTodo(TodoCreateDto dt)
    {
        bool exists = _context.Todos.Any(x => x.Id == dt.Id);

        if (exists)
        {
            return false;
        }

        var todo = new Todo
        {
            Id = dt.Id,
            Title = dt.Title,
            IsCompleted = dt.IsCompleted
        };

        _context.Todos.Add(todo);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateTodo(TodoUpdateDto dt)
    {
        var todo = _context.Todos.FirstOrDefault(x => x.Id == dt.Id);

        if (todo == null)
        {
            return false;
        }

        todo.Title = dt.Title;
        todo.IsCompleted = dt.IsCompleted;

        _context.SaveChanges();

        return true;
    }

    public bool DeleteTodo(int todoId)
    {
        var todo = _context.Todos.FirstOrDefault(x => x.Id == todoId);

        if (todo == null)
        {
            return false;
        }

        _context.Todos.Remove(todo);
        _context.SaveChanges();

        return true;
    }

    public string? uploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return null;

        var uploadPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "media",
            "users"
        );

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }
}