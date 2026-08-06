using data;
using models;

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
}