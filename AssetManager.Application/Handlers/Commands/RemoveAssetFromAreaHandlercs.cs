using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class RemoveAssetFromAreaHandler : IRequestHandler<RemoveAssetFromAreaCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveAssetFromAreaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveAssetFromAreaCommand request, CancellationToken cancellationToken)
    {
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);

        if (area is null)
        {
            return false;
        }

        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AssetId);

        if (asset is null)
        {
            return false;
        }
        
        area.RemoveAsset(asset);
        
        _unitOfWork.Commit();  
        
        return true;
    }
}