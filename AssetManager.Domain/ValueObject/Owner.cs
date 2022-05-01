namespace AssetManager.Domain.ValueObject
{
    public record Owner
    {
        private int _id;
        public string Name { get; }
        public string Email { get; }
        public RoleEnum Role { get; }

        public Owner(string name, string email, RoleEnum role)
        {
            // validate name
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }

            Name = name;

            // validate email
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required", nameof(email));
            }

            Email = email;

            // validate role
            if (role == RoleEnum.None)
            {
                throw new ArgumentException("Role is required", nameof(role));
            }

            Role = role;
        }

        public override string ToString() => $"{Name} ({Email})";

        public static Owner Create(string name, string email, RoleEnum role) => new Owner(name, email, role);
    }

    public enum RoleEnum
    {
        SuperAdmin,
        Admin,
        User,
        None
    }
}