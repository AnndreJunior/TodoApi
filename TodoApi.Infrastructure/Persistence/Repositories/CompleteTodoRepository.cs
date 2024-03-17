using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Errors;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Infrastructure.Persistence.Repositories;

public class CompleteTodoRepository : ICompleteTodoRepository
{
    private readonly AppDbContext _context;

    public CompleteTodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Todo> Execute(Guid id)
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id) ?? throw new TodosNotFoundException("Tarefa não encontrada");

        todo.CompleteTask();

        _context.Todos.Update(todo);

        await _context.SaveChangesAsync();

        return todo;
    }
}
