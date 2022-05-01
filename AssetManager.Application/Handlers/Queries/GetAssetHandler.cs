using AssetManager.Application.DTO;
using AssetManager.Application.Queries;
using AssetManager.Domain.Exceptions;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Queries;

public class GetAssetHandler : IRequestHandler<GetAssetQuery, AssetDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAssetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AssetDto> Handle(GetAssetQuery request, CancellationToken cancellationToken)
    {
        var asset = await _unitOfWork.AssetRepository.GetAsync(request.AssetId);

        return await Task.FromResult(asset.ToDto()) ?? throw new AssetNotFoundException("Asset not found");
    }
}