using Beyond.Application;
using Beyond.Application.Contracts;
using Beyond.Classes;
using Beyond.Contracts;
using Beyond.Repositories;
using Beyond.Repositories.Contracts;
using System.Text.Json.Serialization;

var specificOrigins = "_specificOrigins";

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: specificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddControllers();

builder.Services.AddSingleton<ITodoList, TodoList>();
builder.Services.AddSingleton<ITodoListRepository, TodoListRepository>();
builder.Services.AddSingleton<ITodoListApplication, TodoListApplication>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(specificOrigins);

app.Run();


[JsonSerializable(typeof(ITodoList))]
[JsonSerializable(typeof(TodoList))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
