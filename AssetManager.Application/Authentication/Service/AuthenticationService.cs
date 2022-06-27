using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.Authentication.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public AuthenticationResult Register(string firstName,
        string lastName,
        string username,
        string password,
        RoleEnum role)
    {
        // check if user already exists in User
        if (_unitOfWork.UserRepository.GetUser(username) is not null)
        {
            throw new Exception("User already exists");
        }

        var user = new User
        (
            new UserId(Guid.NewGuid()),
            firstName,
            lastName,
            username,
            password,
            role
        );

        _unitOfWork.UserRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        {
            Token = token,
            User = user
        };
    }

    public AuthenticationResult Login(string username, string password)
    {

        if (_unitOfWork.UserRepository.GetUser(username).Result is not User user)
        {
            throw new Exception("User already exists");
        }

        // check if password equals user password
        if (password != user.Password)
        {
            throw new Exception("Invalid password");
        }
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        {
            Token = token,
            User = user
        };

    }
}
