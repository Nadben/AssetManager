namespace AssetManager.Domain.ValueObject;

public record UserId
{
    public Guid Value { get; }
    public UserId(Guid value)
    {
        // throw if value is empty
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty", nameof(value));
        }

        Value = value;
    }

    public static implicit operator Guid(UserId userId) => userId.Value;

    public static implicit operator UserId(Guid userId) => new UserId(userId);
}
