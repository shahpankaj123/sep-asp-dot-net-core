using models;

namespace services;

public interface ITodoService
{
    List<Todo> GetAllTodos();

    Todo? GetTodoById(int todoId);
}