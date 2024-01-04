using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
        string Email, 
        string LastName,
        string FirstName,
        string Password) : ICommand<Guid>;   
}
