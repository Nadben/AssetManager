using AssetManager.Application.DTO;
using MediatR;

namespace AssetManager.Application.Commands;

public record UpdateAreaCommand(AreaDto AreaDto) : IRequest<bool>;
