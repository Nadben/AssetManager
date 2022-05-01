using AssetManager.Domain.DomainEvent;
using AssetManager.Domain.Exceptions;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Entities
{
    public class Recorder : Asset
    {
        // Add recorder specific properties here

        public List<Camera> Cameras { get; }

        internal Recorder(
            AssetName name,
            AssetIpId ipId,
            ClientPort port,
            UserName userName,
            Password password) : base(name, ipId, port, userName, password)
        {
            Cameras = new List<Camera>();
        }

        public void AddCamera(Camera camera)
        {
            // Add camera to recorder
            if (Cameras.Any(i => i.Id == camera.Id))
            {
                throw new CameraAlreadyExistsException("Camera already exists");
            }

            Cameras.Add(camera);
            AddEvent(new CameraAdded(this, camera));
        }
    }
}