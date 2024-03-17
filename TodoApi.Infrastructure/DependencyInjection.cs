using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Domain.Interfaces;
using TodoApi.Infrastructure.Persistence;
using TodoApi.Infrastructure.Persistence.Repositories;

namespace TodoApi.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt
        => opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

        return builder;
    }

    public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICreateTodoRepository, CreateTodoRepository>();

        return builder;
    }
}
