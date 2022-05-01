using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyAssetIdException : Exception
    {
        public EmptyAssetIdException(string message) : base(message)
        {
        }
        
    }
}