namespace AssetManager.Domain.Repositories;

public interface IUnitOfWork
{
    public IAreaRepository AreaRepository { get; }
    public IAssetRepository AssetRepository { get; }
    public ICameraRepository CameraRepository { get; }
    public IRecorderRepository RecorderRepository { get; }
    public IOwnerRepository OwnerRepository { get; }
    public IUserRepository UserRepository { get; }
    void Commit();
    void CreateTransaction();
    void Rollback();
    void Dispose();
}