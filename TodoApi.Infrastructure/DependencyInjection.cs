using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Infrastructure.Persistence;

namespace TodoApi.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt
        => opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")));

        return builder;
    }
}
