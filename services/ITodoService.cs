using models;
using dto;

namespace services;

public interface ITodoService
{
    List<Todo> GetAllTodos();

    Todo? GetTodoById(int todoId);

    bool CreateTodo(TodoCreateDto dt);

    bool UpdateTodo(TodoUpdateDto dt);

    bool DeleteTodo(int todoId);

    string? uploadImage(IFormFile file);
}