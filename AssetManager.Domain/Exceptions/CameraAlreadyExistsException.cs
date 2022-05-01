using System;

namespace AssetManager.Domain.Exceptions
{
    public class CameraAlreadyExistsException : Exception
    {
        public CameraAlreadyExistsException(string message) : base(message)
        {
        }

    }
}