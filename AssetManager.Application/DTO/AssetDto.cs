using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.DTO;

public class AssetDto : ApiResponse
{
    public AssetId Id { get; }
    public AssetName Name { get; }
    public AssetIpId IpId { get; }
    public ClientPort Port { get; }
    public UserName UserName { get; }
    public Password Password { get; }
    public List<OwnerDto> Owners { get; }

    public AssetDto(AssetId id, 
        AssetName name, 
        AssetIpId ipId, 
        ClientPort port, 
        UserName userName, 
        Password password,
        List<OwnerDto> owners)
    {
        Id = id;
        Name = name;
        IpId = ipId;
        Port = port;
        UserName = userName;
        Password = password;
        Owners = owners;
    }
}