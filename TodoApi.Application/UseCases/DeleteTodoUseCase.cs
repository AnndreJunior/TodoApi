using TodoApi.Domain.Interfaces;

namespace TodoApi.Application.UseCases;

public class DeleteTodoUseCase
{
    private readonly IDeleteTodoRepository _deleteTodoRepository;

    public DeleteTodoUseCase(IDeleteTodoRepository deleteTodoRepository)
    {
        _deleteTodoRepository = deleteTodoRepository;
    }

    public async Task Execute(Guid id)
    {
        await _deleteTodoRepository.Execute(id);
    }
}
