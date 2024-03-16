using TodoApi.Application.Dtos;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Application.UseCases;

public class CreateTodoUseCase
{
    private readonly ICreateTodoRepository _createTodoRepository;

    public CreateTodoUseCase(ICreateTodoRepository createTodoRepository)
    {
        _createTodoRepository = createTodoRepository;
    }

    public async Task<Todo> Execute(CreateTodoDto todoDto)
    {
        var title = todoDto.Title;
        var todo = new Todo(title);

        await _createTodoRepository.Execute(todo);

        return todo;
    }
}
