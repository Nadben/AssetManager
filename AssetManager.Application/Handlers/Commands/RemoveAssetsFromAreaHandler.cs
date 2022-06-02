using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class RemoveAssetsFromAreaHandler : IRequestHandler<RemoveAssetsFromAreaCommand,bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveAssetsFromAreaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveAssetsFromAreaCommand request, CancellationToken cancellationToken)
    {        
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);

        if (area is null)
        {
            return false;
        }

        var asset =  _unitOfWork.AssetRepository.GetAssets(request.Assets);

        if (asset is null)
        {
            return false;
        }
        
        area.RemoveAssets(asset);
        
        _unitOfWork.Commit();  
        
        return true;
    }
}