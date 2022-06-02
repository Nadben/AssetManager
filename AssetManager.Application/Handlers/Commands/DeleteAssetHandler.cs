using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class DeleteAssetHandler : IRequestHandler<DeleteAssetCommand,bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
    {
        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AssetId);

        if (asset is null)
        {
            return false;
        }

        await _unitOfWork.AssetRepository.DeleteAsync(asset);

        return true;
    }
}