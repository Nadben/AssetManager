using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.DTO;

public class OwnerDto
{
    public string Name { get; }
    public string Email { get; }
    public RoleEnum Role { get; }

    public OwnerDto(string name, string email, RoleEnum role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
}