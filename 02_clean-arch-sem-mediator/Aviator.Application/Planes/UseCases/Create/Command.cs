using Aviator.Application.Shared.UseCases.Abstractions;

namespace Aviator.Application.Planes.UseCases.Create;

public record Command(string Name) : ICommand;