using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class AssignOwnerToAssetHandler : IRequestHandler<AssignOwnerToAssetCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignOwnerToAssetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AssignOwnerToAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AssetId);

        if (asset == null)
        {
            return false;
        }

        var owner = _unitOfWork.OwnerRepository.Get(request.Owner);
        asset.AssignOwner(owner);
        _unitOfWork.Commit();

        return true;
    }
}