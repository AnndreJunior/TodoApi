using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Interfaces;

namespace TodoApi.Infrastructure.Persistence.Repositories;

public class GetAllTodosRepository : IGetAllTodosRepository
{
    private readonly AppDbContext _context;

    public GetAllTodosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> Execute()
    {
        var todos = await _context.Todos.ToListAsync();

        return todos;
    }
}
