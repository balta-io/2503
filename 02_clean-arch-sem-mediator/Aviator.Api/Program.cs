using CreatePlaneCommand = Aviator.Application.Planes.UseCases.Create.Command;
using CreatePlaneHandler = Aviator.Application.Planes.UseCases.Create.Handler;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CreatePlaneHandler>();

var app = builder.Build();

app.MapPost("/", async (CreatePlaneCommand command, CreatePlaneHandler handler) => await handler.HandleAsync(command));

app.Run();