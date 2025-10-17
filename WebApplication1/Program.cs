using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Extension;
using MyMediator.Types;
using Scalar.AspNetCore;
using System.Reflection;
using WebApplication1.CQRS.Newstydent;
using WebApplication1.DB;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<Db131025Context>();
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        // CQRS
        builder.Services.AddScoped<MyMediator.Types.Mediator>();
        builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}









