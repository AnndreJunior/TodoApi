using TodoApi.Domain.Entities;
using TodoApi.Domain.Errors;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Application.UseCases;

public class GetAllTodosUseCase
{
    private readonly IGetAllTodosRepository _getAllTodosRepository;

    public GetAllTodosUseCase(IGetAllTodosRepository getAllTodosRepository)
    {
        _getAllTodosRepository = getAllTodosRepository;
    }

    public async Task<List<Todo>> Execute()
    {
        var todos = await _getAllTodosRepository.Execute();

        bool todosNotFound = todos.Count == 0;

        if (todosNotFound)
            throw new TodosNotFoundException("Nenhuma tarefa encontrada");

        return todos;
    }
}
