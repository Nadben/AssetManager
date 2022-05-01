using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record AssignOwnerToAreaCommand(string Owner, Guid AreaId) : IRequest<bool>;