using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Application.UseCases;

public class CompleteTodoUseCase
{
    private readonly ICompleteTodoRepository _completeTodoRepository;

    public CompleteTodoUseCase(ICompleteTodoRepository completeTodoRepository)
    {
        _completeTodoRepository = completeTodoRepository;
    }

    public async Task<Todo> Execute(Guid id)
    {
        var todo = await _completeTodoRepository.Execute(id);

        return todo;
    }
}
