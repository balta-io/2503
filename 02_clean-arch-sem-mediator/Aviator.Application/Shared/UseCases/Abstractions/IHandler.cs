namespace Aviator.Application.Shared.UseCases.Abstractions;

public interface IHandler<in TCommand, TResponse>
    where TCommand : ICommand
    where TResponse : IResponse
{
    Task<IResponse> HandleAsync(ICommand command, CancellationToken cancellationToken = default);
}