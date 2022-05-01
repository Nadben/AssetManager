namespace AssetManager.Domain.ValueObject
{
    public record AssetIpId
    {
        public string IpAddress { get; }
        
        public AssetIpId(string ipAddress)
        {
            // add ip address validation and throw exception if invalid
            IpAddress = ipAddress;
        }
        
        public static implicit operator string(AssetIpId assetIpId) => assetIpId.IpAddress;
        public static implicit operator AssetIpId(string ipAddress) => new (ipAddress);
        public override string ToString() => IpAddress;
        
    }
}