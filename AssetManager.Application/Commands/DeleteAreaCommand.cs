using MediatR;

namespace AssetManager.Application.Commands;

public record DeleteAreaCommand(Guid AreaId) : IRequest<bool>;