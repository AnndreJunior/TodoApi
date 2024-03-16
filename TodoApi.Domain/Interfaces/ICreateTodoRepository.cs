using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces;

public interface ICreateTodoRepository
{
    public Task Execute(Todo todo);
}
