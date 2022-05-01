using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyAreaIdException : Exception
    {
        public EmptyAreaIdException(string message) : base(message)
        {
        }
    
        
    }
}