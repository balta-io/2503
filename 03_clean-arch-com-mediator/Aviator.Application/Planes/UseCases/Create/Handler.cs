using MediatR;

namespace Aviator.Application.Planes.UseCases.Create;

public class Handler : IRequestHandler<Command, Response>
{
    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return new Response("Account created");
    }
}