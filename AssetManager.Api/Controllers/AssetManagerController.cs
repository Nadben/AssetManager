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

    /// <summary>
    /// this endpoint is used to get the Area created with its assigned Asset.
    /// </summary>
    /// <param name="GetAreaQuery"></param>
    /// <returns></returns>
    // [Authorize(Roles = "SuperAdmin")]
    [Authorize]
    [HttpGet("Area/{AreaId:guid}")]
    [ProducesResponseType(typeof(AreaDto), 200)]
    public async Task<ActionResult<AreaDto>> Get([FromRoute] GetAreaQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// This endpoint is used to get the Asset created.
    /// </summary>
    /// <param name="GetAssetQuery"></param>
    /// <returns></returns>
    // [Authorize(Roles = "SuperAdmin")]
    [HttpGet("Asset/{AssetId:guid}")]
    [ProducesResponseType(typeof(AssetDto), 200)]
    public async Task<ActionResult<AssetDto>> Get([FromRoute] GetAssetQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// this endpoint is used to create an Area.
    /// </summary>
    /// <param name="CreateAreaCommand"></param>
    /// <returns></returns>
    // [Authorize]
    [HttpPost("Area")]
    public async Task<IActionResult> Post([FromBody] CreateAreaCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, command);
    }

    /// <summary>
    /// This endpoint is used to create an Asset.
    /// </summary>
    /// <param name="CreateAssetCommand"></param>
    /// <returns></returns>
    // [Authorize]
    [HttpPost("Asset")]
    public async Task<IActionResult> Post([FromBody] CreateAssetCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = result }, command);
    }

    /// <summary>
    /// this endpoint is used to assign an Asset to an Area.
    /// </summary>
    /// <param name="AssignAssetToAreaCommand"></param>
    /// <returns></returns>
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost("{AreaId:guid}/Assets/{AssetId:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignAssetToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to assign an owner to an Area.
    /// </summary>
    /// <param name="AssignOwnerToAreaCommand"></param>
    /// <returns></returns>
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost("{areaid:guid}/Area/{ownerid:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to Assign an owner to an Asset.
    /// </summary>
    /// <param name="AssignOwnerToAssetCommand"></param>
    /// <returns></returns>
    [HttpPost("{AreaId:guid}/Asset/{AssetId:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAssetCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to delete an Area.
    /// </summary>
    /// <param name="DeleteAreaCommand"></param>
    /// <returns></returns>
    [HttpDelete("{AreaId}")]
    public async Task<IActionResult> Delete([FromBody] DeleteAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{AssetId}")]
    public async Task<IActionResult> Delete([FromBody] DeleteAssetCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}