using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Queries;

public record GetAreaQuery(Guid AreaId) : IRequest<AreaDto>
{
}