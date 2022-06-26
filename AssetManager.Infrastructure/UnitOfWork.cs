using AssetManager.Domain.Repositories;

namespace AssetManager.Infrastructure;

public class UnitOfWork: IUnitOfWork, IDisposable 
{
    private readonly AssetManagerContext _context;
    private readonly IAreaRepository _areaRepository;
    private readonly IAssetRepository _assetRepository;
    private readonly ICameraRepository _cameraRepository;
    private readonly IRecorderRepository _recorderRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IUserRepository _userRepository;

    private bool _disposed;
    
    public IAreaRepository AreaRepository => _areaRepository;
    public IAssetRepository AssetRepository => _assetRepository;
    public ICameraRepository CameraRepository => _cameraRepository;
    public IRecorderRepository RecorderRepository => _recorderRepository;
    public IOwnerRepository OwnerRepository => _ownerRepository;
    public IUserRepository UserRepository => _userRepository;

    public UnitOfWork(AssetManagerContext context,
        IAreaRepository areaRepository,
        IAssetRepository assetRepository,
        ICameraRepository cameraRepository,
        IRecorderRepository recorderRepository,
        IOwnerRepository ownerRepository,
        IUserRepository userRepository)
    {
        _context = context;
        _areaRepository = areaRepository;
        _assetRepository = assetRepository;
        _cameraRepository = cameraRepository;
        _recorderRepository = recorderRepository;
        _ownerRepository = ownerRepository;
        _userRepository = userRepository;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void CreateTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    public void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}
