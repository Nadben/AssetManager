using AssetManager.Domain.Exceptions;

namespace AssetManager.Domain.ValueObject
{
    public record UserName
    {
        public string Value { get; }    
        
        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserNameException("UserName cannot be empty");
            }

            Value = value;
        }
        
        public static implicit operator string(UserName userName) => userName.Value;
        public static implicit operator UserName(string value) => new (value);
    }
}