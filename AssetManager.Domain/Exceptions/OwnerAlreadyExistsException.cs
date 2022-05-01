namespace AssetManager.Domain.Entities;

public class OwnerAlreadyExistsException : Exception
{
    public OwnerAlreadyExistsException(string ownerAlreadyExists) : base(ownerAlreadyExists)
    {
    }
}