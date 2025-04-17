using Mediator.Abstractions;
using Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IMediator, Mediator.Mediator>();
services.AddTransient<AccountRepository>();
// services.AddTransient<IHandler<CreateAccountRequest, string>, CreateAccountHandler>();
services.AddMediator(typeof(Program).Assembly);

var serviceProvider = services.BuildServiceProvider();
var mediator = serviceProvider.GetRequiredService<IMediator>();

var request = new CreateAccountRequest { Username = "batman", Password = "12345566" };
var result = await mediator.SendAsync(request);
Console.WriteLine(result);


public class AccountRepository
{
    public void Save() 
        => Console.WriteLine("Saving...");
}

public class CreateAccountRequest : IRequest<string>
{
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}

public class CreateAccountHandler(AccountRepository accountRepository) : IHandler<CreateAccountRequest, string>
{
    public Task<string> HandleAsync(CreateAccountRequest request, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Creating account {request.Username}...");
        accountRepository.Save();
        return Task.FromResult($"{request.Username} created");
    }
}