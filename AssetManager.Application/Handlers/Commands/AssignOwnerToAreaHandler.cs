using AssetManager.Application.Commands;
using AssetManager.Domain.Repositories;
using MediatR;

namespace AssetManager.Application.Handlers.Commands;

public class AssignOwnerToAreaHandler : IRequestHandler<AssignOwnerToAreaCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public AssignOwnerToAreaHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(AssignOwnerToAreaCommand request, CancellationToken cancellationToken)
    {
        var area = await _unitOfWork.AreaRepository.GetAsync(request.AreaId);

        if (area == null)
        {
            return false;
        }

        var owner = _unitOfWork.OwnerRepository.Get(request.Owner);
        area.AssignOwner(owner);
        _unitOfWork.Commit();

        return true;
    }
}