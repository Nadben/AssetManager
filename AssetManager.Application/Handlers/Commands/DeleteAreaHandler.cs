using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class DeleteAreaHandler : IRequestHandler<DeleteAreaCommand,bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAreaHandler(IUnitOfWork unitOfWork)
    {   
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
    {        
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);

        if (area is null)
        {
            return false;
        }

        _unitOfWork.AreaRepository.DeleteAsync(area);

        return true;
    }
}