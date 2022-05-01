using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyAssetIpIdException : Exception
    {
        public EmptyAssetIpIdException(string message) : base(message)
        {
        }
    }
}