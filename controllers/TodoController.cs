using Microsoft.AspNetCore.Mvc;
using services;
using dto;

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
            return NotFound(new CommonResponse("Todo Data Not Found", 400));

        return Ok(todo);
    }

    [HttpPost("CreateTodo")]
    public IActionResult CreateTodos(TodoCreateDto dt)
    {
        bool result = todoService.CreateTodo(dt);

        if (!result)
        {
            return Conflict(new CommonResponse("Todo with this Id already exists", 400));
        }

        return StatusCode(StatusCodes.Status201Created, new CommonResponse("Todo Created Successfully", 201));
    }

    [HttpPut("UpdateTodo")]
    public IActionResult UpdateTodo(TodoUpdateDto dt)
    {
        bool result = todoService.UpdateTodo(dt);

        if (!result)
        {
            return NotFound(new CommonResponse("Todo Data Not Found", 404));
        }

        return Ok(new CommonResponse("Todo Updated Successfully", 200));
    }

    [HttpDelete("DeleteTodo/{todoId}")]
    public IActionResult DeleteTodo(int todoId)
    {
        bool result = todoService.DeleteTodo(todoId);

        if (!result)
        {
            return NotFound(new CommonResponse("Todo Data Not Found", 404));
        }

        return Ok(new CommonResponse("Todo Deleted Successfully", 200));
    }

    [HttpPost("Upload")]
    public IActionResult UploadFile(IFormFile file)
    {
        string? fileName = todoService.uploadImage(file);

        if (fileName == null)
        {
            return BadRequest(new CommonResponse("Upload failed", 400));
        }

        var fileUrl = $"{Request.Scheme}://{Request.Host}/media/users/{fileName}";

        return Ok(new
        {
            message = "File uploaded successfully",
            fileName = fileName,
            url = fileUrl
        });
    }
}