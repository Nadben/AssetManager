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

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        {
            Token = token,
            User = user
        };
    }

    public AuthenticationResult Login(string username, string password)
    {
        // check if user exists
        //if (!_unitOfWork.UserRepository.UserExists(username))
        //{
        //    return null;
        //}

        var user = _unitOfWork.UserRepository.GetUser(username);


        // check if password equals user password


        // generate jwt token

        // return authentication result
        throw new NotImplementedException();
    }
}
