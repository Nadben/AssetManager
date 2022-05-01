using System;

namespace AssetManager.Domain.Exceptions
{
    public class EmptyPasswordException : Exception 
    {
        public EmptyPasswordException() : base("Password cannot be empty")
        {
        }
    }
}