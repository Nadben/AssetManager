using System;
using AssetManager.Domain.Exceptions;

namespace AssetManager.Domain.ValueObject
{
    public record AssetId 
    {
        public Guid Value { get; }

        public AssetId(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new EmptyAssetIdException("AssetId cannot be empty");
            }
            
            Value = value;
        }
        
        public static implicit operator Guid(AssetId id) => id.Value;
        public static implicit operator AssetId(Guid id) => new (id);

    }
}