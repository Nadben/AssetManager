using AssetManager.Domain.Entities;
using AssetManager.Domain.Factories.Interfaces;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories;

public class AssetFactory : IAssetFactory
{
    public Asset Create(AssetName assetName,
        AssetIpId assetIpId,
        ClientPort clientPort,
        UserName userName,
        Password password)
    {
        return new Asset(assetName, assetIpId, clientPort, userName, password);
    }

    public Asset CreateWithDefaultValues(
        AssetName assetName,
        AssetIpId assetIpId,
        ClientPort clientPort,
        UserName userName,
        Password password)
    {
        throw new NotImplementedException();
    }
}