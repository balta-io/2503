using Aviator.Application;
using MediatR;
using CreatePlaneCommand = Aviator.Application.Planes.UseCases.Create.Command;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();

var app = builder.Build();

app.MapPost("/", async (CreatePlaneCommand command, ISender handler) => await handler.Send(command));

app.Run();