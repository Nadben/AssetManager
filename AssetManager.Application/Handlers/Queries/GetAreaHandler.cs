using AssetManager.Application.DTO;
using AssetManager.Application.Queries;
using AssetManager.Domain.Exceptions;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Queries;

public class GetAreaHandler : IRequestHandler<GetAreaQuery, AreaDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAreaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AreaDto> Handle(GetAreaQuery request, CancellationToken cancellationToken)
    {
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);
        
        return await Task.FromResult(area.ToDto()) ?? throw new AssetNotFoundException("Asset not found");
    }
}