using Microsoft.AspNetCore.Mvc;
using services;

namespace controllers;

[ApiController]
[Route("web/api/v1/todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoService todoService;

    public TodoController(ITodoService todoService)
    {
        this.todoService = todoService;
    }

    [HttpGet("GetAllTodos")]
    public IActionResult GetAllTodos()
    {
        var todos = todoService.GetAllTodos();
        return Ok(todos);
    }

    [HttpGet("GetTodo/{id}")]
    public IActionResult GetTodoById(int id)
    {
        var todo = todoService.GetTodoById(id);

        if (todo == null)
            return NotFound("Todo not found");

        return Ok(todo);
    }
}