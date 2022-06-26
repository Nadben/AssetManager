using AssetManager.Domain.Entities;

namespace AssetManager.Application.Authentication.Service;

public class AuthenticationResult
{
    public string Token { get; set; }
    public User User { get; set; }
}