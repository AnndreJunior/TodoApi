using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Dtos;
using TodoApi.Application.UseCases;

namespace TodoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreateTodoController : ControllerBase
{
    private readonly CreateTodoUseCase _createTodoUseCase;

    public CreateTodoController(CreateTodoUseCase createTodoUseCase)
    {
        _createTodoUseCase = createTodoUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Handle(CreateTodoDto request)
    {
        try
        {
            var todo = await _createTodoUseCase.Execute(request);

            return Created("create todo", todo);
        }
        catch (InvalidDataException err)
        {
            return BadRequest(new
            {
                error = err.Message
            });
        }
    }
}
