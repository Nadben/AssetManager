using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record CreateAssetCommand(AssetDto AssetDto): IRequest<Guid>;