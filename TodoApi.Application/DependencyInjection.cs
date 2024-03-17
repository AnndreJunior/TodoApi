using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application.UseCases;

namespace TodoApi.Application;

public static class DependencyInjection
{
    public static WebApplicationBuilder UseApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateTodoUseCase>();
        builder.Services.AddScoped<GetAllTodosUseCase>();
        builder.Services.AddScoped<CompleteTodoUseCase>();
        builder.Services.AddScoped<DeleteTodoUseCase>();

        return builder;
    }
}
