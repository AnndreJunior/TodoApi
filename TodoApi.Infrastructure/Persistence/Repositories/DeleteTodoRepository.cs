using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Errors;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Infrastructure.Persistence.Repositories;

public class DeleteTodoRepository : IDeleteTodoRepository
{
    private readonly AppDbContext _context;

    public DeleteTodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Execute(Guid id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id) ?? throw new TodosNotFoundException("Tarefa não encontrada");
        _context.Remove(todo);

        await _context.SaveChangesAsync();
    }
}
