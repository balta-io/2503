using MediatR;

namespace Aviator.Application.Planes.UseCases.Create;

public record Command(string Name) : IRequest<Response>;