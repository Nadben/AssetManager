using AssetManager.Domain.Entities;

namespace AssetManager.Application.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
