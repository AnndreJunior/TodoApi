using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.UseCases;
using TodoApi.Domain.Errors;

namespace TodoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompleteTodoController : ControllerBase
{
    private readonly CompleteTodoUseCase _completeTodoUseCase;

    public CompleteTodoController(CompleteTodoUseCase completeTodoUseCase)
    {
        _completeTodoUseCase = completeTodoUseCase;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Handle(Guid id)
    {
        try
        {
            var todo = await _completeTodoUseCase.Execute(id);

            return Ok(todo);
        }
        catch (TodosNotFoundException err)
        {
            return NotFound(new
            {
                error = err.Message
            });
        }
    }
}
