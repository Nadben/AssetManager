using MediatR;

namespace AssetManager.Application.Commands;

public record AssignOwnerToAssetCommand(string Owner, Guid AssetId) : IRequest<bool>;