using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Queries;

public record GetAssetQuery(Guid AssetId) : IRequest<AssetDto>, IRequest;