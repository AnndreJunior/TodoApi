using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.UseCases;
using TodoApi.Domain.Errors;

namespace TodoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeleteTodoController : ControllerBase
{
    private readonly DeleteTodoUseCase _deleteTodoUseCase;

    public DeleteTodoController(DeleteTodoUseCase deleteTodoUseCase)
    {
        _deleteTodoUseCase = deleteTodoUseCase;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Handle(Guid id)
    {
        try
        {
            await _deleteTodoUseCase.Execute(id);

            return Ok();
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
