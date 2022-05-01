namespace AssetManager.Domain.Exceptions
{
    public class AssetNotFoundException : Exception
    {
        public AssetNotFoundException(string assetNotFound) : base(assetNotFound)
        {
        }
    }
}