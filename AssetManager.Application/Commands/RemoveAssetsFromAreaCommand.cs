using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record RemoveAssetsFromAreaCommand(Guid AreaId, IEnumerable<Guid> Assets) :IRequest<bool>;