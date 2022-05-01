using AssetManager.Domain.Exceptions;

namespace AssetManager.Domain.ValueObject
{
    public record AssetName
    {
        public string Name { get; private set; }    
        
        public AssetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyAssetNameException("Asset name cannot be empty");
            }

            Name = name;
        }
        
        public static implicit operator string(AssetName assetName) => assetName.Name;
        public static implicit operator AssetName(string name) => new (name);
    }
}