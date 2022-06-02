using MediatR;

namespace AssetManager.Application.Commands;

public record DeleteAssetCommand(Guid AssetId) : IRequest<bool>;