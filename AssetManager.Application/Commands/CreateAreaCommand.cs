using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record CreateAreaCommand(AreaDto AreaDto) : IRequest<Guid>;