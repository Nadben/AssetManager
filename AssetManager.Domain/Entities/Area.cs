using AssetManager.Domain.Domain;
using AssetManager.Domain.DomainEvent;
using AssetManager.Domain.Exceptions;
using AssetManager.Domain.ValueObject;
namespace AssetManager.Domain.Entities
{
    public class Area : AggregateRoot<AreaId>
    {
        public AreaName Name { get; }
        public List<Asset> Assets { get; }
        public List<Owner> Owners { get; }

        internal Area(AreaName name)
        {
            Id = new AreaId(Guid.NewGuid());
            Name = name;
            Assets = new List<Asset>();
            Owners = new List<Owner>();
        }
        
        internal Area(AreaName name,
            List<Asset> assets,
            List<Owner> owners)
        {
            Id = new AreaId(Guid.NewGuid());
            Name = name;
            Assets = assets;
            Owners = owners;
        }

        public void AddAsset(Asset asset)
        {
            if (Assets.Contains(asset))
                throw new AssetAlreadyExistsException("Asset already exists");

            Assets.Add(asset);

            AddEvent(new AssetAdded(this, asset));
        }

        public void AddAssets(IEnumerable<Asset> assets)
        {
            foreach (var asset in assets)
            {
                AddAsset(asset);
            }
        }

        public void RemoveAsset(Asset asset)
        {
            if (!Assets.Contains(asset))
                throw new AssetNotFoundException("Asset not found");

            Assets.Remove(asset);

            AddEvent(new AssetRemoved(this, asset));
        }

        public void RemoveAssets(IEnumerable<Asset> assets)
        {
            foreach (var asset in assets)
            {
                RemoveAsset(asset);
            }
        }

        public void AssignOwner(Owner owner)
        {
            if (Owners.Exists(x => x.Email == owner.Email))
            {
                throw new OwnerAlreadyExistsException("Owner already exists");
            }
            Owners.Add(owner);
            AddEvent(new OwnerAssignedToArea(this, owner));
        }

        public void RemoveOwner(Owner owner)
        {
            Owners.Remove(owner);
            AddEvent(new OwnerRemovedFromArea(this, owner));
        }

        public void AssignOwners(IEnumerable<Owner> owners)
        {
            foreach (var owner in owners)
            {
                AssignOwner(owner);
            }
        }

        public void RemoveOwners(IEnumerable<Owner> owners)
        {
            foreach (var owner in owners)
            {
                RemoveOwner(owner);
            }
        }


        private Area()
        {
            // for entity framework
        }
    }
}