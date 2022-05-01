using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyAreaNameException : Exception
    {

        public EmptyAreaNameException(string message)
            : base(message)
        {
        }
        
    }
}