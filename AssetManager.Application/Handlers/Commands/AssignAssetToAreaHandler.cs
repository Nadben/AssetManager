using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class AssignAssetToAreaHandler : IRequestHandler<AssignAssetToAreaCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignAssetToAreaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AssignAssetToAreaCommand request, CancellationToken cancellationToken)
    {
        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AreaId);
        
        if(asset == null)
        {
            return false;
        }
        
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);
        
        if(area == null)
        {
            return false;
        }
        
        area.AddAsset(asset);
        
        _unitOfWork.Commit();

        return true;
    }
}