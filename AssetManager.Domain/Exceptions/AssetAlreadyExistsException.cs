using System;

namespace AssetManager.Domain.Exceptions
{
    public class AssetAlreadyExistsException : Exception
    {
        public AssetAlreadyExistsException(string message) : base(message)
        {
        }

    }
}