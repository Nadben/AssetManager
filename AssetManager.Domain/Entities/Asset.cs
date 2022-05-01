using AssetManager.Domain.Domain;
using AssetManager.Domain.DomainEvent;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Entities
{
    public class Asset : AggregateRoot<AssetId>
    {
        public AssetName Name { get; }
        public AssetIpId IpId { get; }
        public ClientPort Port { get; }
        public UserName UserName { get; }
        public Password Password { get; }
        public List<Owner> Owners { get; }

        internal Asset(
            AssetName name,
            AssetIpId ipId,
            ClientPort port,
            UserName userName,
            Password password)
        {
            Id = new AssetId(Guid.NewGuid());
            Name = name;
            IpId = ipId;
            Port = port;
            UserName = userName;
            Password = password;
            Owners = new List<Owner>();
        }

        // for entity framework
        private Asset()
        {
        }

        public void AssignOwner(Owner owner)
        {
            if (Owners.Exists(x => x.Email == owner.Email))
            {
                throw new OwnerAlreadyExistsException("Owner already exists");
            }

            Owners.Add(owner);
            AddEvent(new OwnerAssignedToAsset(this, owner));
        }

        public void RemoveOwner(Owner owner)
        {
            Owners.Remove(owner);
            AddEvent(new OwnerRemovedFromAsset(this, owner));
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
    }
}