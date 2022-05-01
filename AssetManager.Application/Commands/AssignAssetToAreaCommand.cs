using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record AssignAssetToAreaCommand(Guid AssetId, Guid AreaId) : IRequest<bool>
{
}