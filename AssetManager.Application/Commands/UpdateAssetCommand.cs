using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record UpdateAssetCommand(AssetDto AssetDto) : IRequest<bool>;
