namespace TodoApi.Domain.Interfaces;

public interface IDeleteTodoRepository
{
    public Task Execute(Guid id);
}
