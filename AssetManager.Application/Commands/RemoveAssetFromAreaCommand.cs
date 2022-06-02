using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record RemoveAssetFromAreaCommand(Guid AreaId, Guid AssetId) : IRequest<bool>;