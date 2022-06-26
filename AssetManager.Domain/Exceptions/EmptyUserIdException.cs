namespace AssetManager.Domain.Exceptions
{
    internal class EmptyUserIdException : Exception
    {
        public EmptyUserIdException()
        {
        }

        public EmptyUserIdException(string message) : base(message)
        {
        }

        public EmptyUserIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
