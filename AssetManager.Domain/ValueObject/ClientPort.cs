namespace AssetManager.Domain.ValueObject
{
    public record ClientPort
    {
        public int Port { get; set; }

        public ClientPort(int port)
        {
            // add validation and throw exception if invalid
            Port = port;
        }
        
        public static implicit operator int(ClientPort clientPort) => clientPort.Port;
        public static implicit operator ClientPort(int port) => new (port);
    }
}