using AssetManager.Application.Authentication.Service;
using AssetManager.Application.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManager.Api.Controllers;

[Route("Authentication/v1")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var authenticationResult = _authenticationService.Register(request.FirstName,
            request.LastName,
            request.Username, 
            request.Password,
            request.Role);

        return Ok(authenticationResult);
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Get(LoginRequest loginRequest)
    {
        var authenticationResult = _authenticationService.Login(loginRequest.Username, loginRequest.Password);

        return Ok(authenticationResult);
    }
}
