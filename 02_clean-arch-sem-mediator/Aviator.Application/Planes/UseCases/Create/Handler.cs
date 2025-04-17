using Aviator.Application.Shared.UseCases.Abstractions;

namespace Aviator.Application.Planes.UseCases.Create;

public class Handler : IHandler<Command, Response>
{
    public async Task<IResponse> HandleAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1, cancellationToken);
        return new Response("Account created");
    }
}