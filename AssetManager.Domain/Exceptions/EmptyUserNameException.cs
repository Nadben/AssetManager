using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyUserNameException : Exception
    {
        public EmptyUserNameException(string message) : base(message)
        {
        }
    }
    
}