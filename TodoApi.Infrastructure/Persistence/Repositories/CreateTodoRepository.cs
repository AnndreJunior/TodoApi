using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Infrastructure.Persistence.Repositories;

public class CreateTodoRepository : ICreateTodoRepository
{
    private readonly AppDbContext _context;

    public CreateTodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Execute(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }
}
