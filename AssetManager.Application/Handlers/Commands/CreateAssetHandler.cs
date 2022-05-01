using AssetManager.Application.Commands;
using AssetManager.Domain.Factories.Interfaces;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class CreateAssetHandler : IRequestHandler<CreateAssetCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssetFactory _assetFactory;
    private readonly IOwnerFactory _ownerFactory;

    public CreateAssetHandler(IUnitOfWork unitOfWork,
        IAssetFactory assetFactory,
        IOwnerFactory ownerFactory)
    {
        _unitOfWork = unitOfWork;
        _assetFactory = assetFactory;
        _ownerFactory = ownerFactory;
    }

    public async Task<Guid> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AssetDto.Id);

        if (asset != null)
        {
            return Guid.Empty;
        }

        var newAsset = _assetFactory.Create(
            request.AssetDto.Name,
            request.AssetDto.IpId,
            request.AssetDto.Port,
            request.AssetDto.UserName,
            request.AssetDto.Password);

        if (request.AssetDto.Owners?.Any() != null)
        {
            foreach (var ownerDto in request.AssetDto.Owners)
            {
                var owner = _ownerFactory.Create(ownerDto.Name, ownerDto.Email, ownerDto.Role);
                newAsset.AssignOwner(owner);
            }
        }

        await _unitOfWork.AssetRepository.AddAsync(newAsset).ConfigureAwait(false);
        _unitOfWork.Commit();

        return newAsset.Id;
    }
}