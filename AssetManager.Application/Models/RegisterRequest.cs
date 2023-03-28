using AssetManager.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Application.Models;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public RoleEnum Role { get; set; }
}
