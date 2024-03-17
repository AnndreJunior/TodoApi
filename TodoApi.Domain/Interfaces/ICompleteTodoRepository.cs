using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces;

public interface ICompleteTodoRepository
{
    public Task<Todo> Execute(Guid id);
}
