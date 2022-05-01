using AssetManager.Application.Commands;
using AssetManager.Application.DTO;
using AssetManager.Application.Queries; 
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace AssetManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetManagerController : Controller
{
    private readonly ILogger<AssetManagerController> _logger;
    private readonly IMediator _mediator;

    public AssetManagerController(ILogger<AssetManagerController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    // [Authorize(Roles = "SuperAdmin")]
    [Authorize]
    [HttpGet("Area/{AreaId:guid}")]
    [ProducesResponseType(typeof(AreaDto), 200)]
    public async Task<ActionResult<AreaDto>> Get([FromRoute] GetAreaQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    // [Authorize(Roles = "SuperAdmin")]
    [HttpGet("Asset/{AssetId:guid}")]
    [ProducesResponseType(typeof(AssetDto), 200)]
    public async Task<ActionResult<AssetDto>> Get([FromRoute] GetAssetQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    // [Authorize]
    [HttpPost("Area")]
    public async Task<IActionResult> Post([FromBody] CreateAreaCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, command);
    }
    // [Authorize]
    [HttpPost("Asset")]
    public async Task<IActionResult> Post([FromBody] CreateAssetCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, command);
    }
    
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost("{AreaId:guid}/Assets/{AssetId:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignAssetToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost("{areaid:guid}/Area/{ownerid:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPost("{AreaId:guid}/Asset/{AssetId:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAssetCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}