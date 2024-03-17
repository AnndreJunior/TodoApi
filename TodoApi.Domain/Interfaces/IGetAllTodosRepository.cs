using TodoApi.Domain.Entities;

namespace TodoApi.Domain.Interfaces;

public interface IGetAllTodosRepository
{
    public Task<List<Todo>> Execute();
}
