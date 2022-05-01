using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Entities
{
    public class Camera : Asset
    {
        // Add Camera specific properties here

        internal Camera(
            AssetName name,
            AssetIpId ipId,
            ClientPort port,
            UserName userName,
            Password password) : base(name, ipId, port, userName, password)
        {
        }
    }
}