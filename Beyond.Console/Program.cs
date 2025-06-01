using Beyond.Application;
using Beyond.Application.Contracts;
using Beyond.Classes;
using Beyond.Console;
using Beyond.Contracts;
using Beyond.Repositories;
using Beyond.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddTransient<App>();
builder.Services.AddSingleton<ITodoList, TodoList>();
builder.Services.AddSingleton<ITodoListRepository, TodoListRepository>();
builder.Services.AddSingleton<ITodoListApplication, TodoListApplication>();

var app = builder.Build();
var myApp = app.Services.GetRequiredService<App>();
myApp.Run();