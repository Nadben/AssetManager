using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.Authentication.Service;

public interface IAuthenticationService
{
    AuthenticationResult Login(string username, string password);
    AuthenticationResult Register(string firstName, string lastName, string username, string password, RoleEnum role);
}