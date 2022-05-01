using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories.Interfaces;

public interface IAssetFactory
{
    Asset Create(AssetName assetName,
        AssetIpId assetIpId, 
        ClientPort clientPort,
        UserName userName,
        Password password);
    
    Asset CreateWithDefaultValues(
        AssetName assetName,
        AssetIpId assetIpId, 
        ClientPort clientPort,
        UserName userName,
        Password password);
}