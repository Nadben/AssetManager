using AssetManager.Domain.Exceptions;

namespace AssetManager.Domain.ValueObject
{
    public record Password
    {
        public string Value { get; }

        public Password(string value)
        {
            // check if password is valid
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPasswordException();
            }

            Value = value;
        }

        public static implicit operator string(Password password) => password.Value;
        public static implicit operator Password(string value) => new(value);
    }
}