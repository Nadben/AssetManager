using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyAssetNameException : Exception
    {
        public EmptyAssetNameException(string message) : base(message)
        {
        }
    }

}