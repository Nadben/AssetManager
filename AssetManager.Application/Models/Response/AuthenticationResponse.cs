namespace AssetManager.Application.Models.Response;

public class AuthenticationResponse
{
    public Guid Id { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
}
