using AssetManager.Application.Commands;
using AssetManager.Domain.Entities;
using AssetManager.Domain.Factories.Interfaces;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.ValueObject;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class CreateAreaHandler : IRequestHandler<CreateAreaCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAreaFactory _areaFactory;
    private readonly IAssetFactory _assetFactory;
    private readonly IOwnerFactory _ownerFactory;

    public CreateAreaHandler(IUnitOfWork unitOfWork,
        IAreaFactory areaFactory,
        IAssetFactory assetFactory,
        IOwnerFactory ownerFactory)
    {
        _unitOfWork = unitOfWork;
        _areaFactory = areaFactory;
        _assetFactory = assetFactory;
        _ownerFactory = ownerFactory;
    }

    public async Task<Guid> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
    {
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaDto.Id);

        if (area != null)
        {
            // already exists exception
            return Guid.Empty;
        }

        var assets = new List<Asset>();
        if (request.AreaDto.Assets.Any())
        {
            // create list of assets
            assets.AddRange(request.AreaDto.Assets
                .Select(assetDto => _assetFactory.Create(assetDto.Name, assetDto.IpId, assetDto.Port, assetDto.UserName, assetDto.Password)));
        }

        var owners = new List<Owner>();
        if (request.AreaDto.Owners.Any())
        {
            // create list of owners
            owners.AddRange(request.AreaDto.Owners
                .Select(ownerDto => _ownerFactory.Create(ownerDto.Name, ownerDto.Email, ownerDto.Role)));
        }

        var newArea = _areaFactory.CreateWithDefaultValues(request.AreaDto.Name, assets, owners);

        await _unitOfWork.AreaRepository.AddAsync(newArea ?? throw new ArgumentNullException(nameof(area)));
        _unitOfWork.Commit();
        return newArea.Id;
    }
}