using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.UseCases;
using TodoApi.Domain.Errors;

namespace TodoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetTodosController : ControllerBase
{
    private readonly GetAllTodosUseCase _getAllTodosUseCase;

    public GetTodosController(GetAllTodosUseCase getAllTodosUseCase)
    {
        _getAllTodosUseCase = getAllTodosUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Handle()
    {
        try
        {
            var todos = await _getAllTodosUseCase.Execute();

            return Ok(todos);
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
