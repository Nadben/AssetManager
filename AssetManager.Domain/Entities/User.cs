using AssetManager.Domain.Domain;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Entities
{
    public class User : AggregateRoot<UserId>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public RoleEnum Role { get; private set; }

        public User(UserId id, string firstName, string lastName, string username, string password, RoleEnum role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Role = role;
        }

        private User()
        {
        }
    }
}
