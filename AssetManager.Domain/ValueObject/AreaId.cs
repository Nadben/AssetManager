using AssetManager.Domain.Exceptions;

namespace AssetManager.Domain.ValueObject
{
    public record struct AreaId
    {
        public Guid Value { get;  }

        public AreaId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyAreaIdException("Value cannot be empty");
            }
            
            Value = value;
        }
        
        public static implicit operator Guid(AreaId id) => id.Value;
        public static implicit operator AreaId(Guid id) => new AreaId(id);
    }
}