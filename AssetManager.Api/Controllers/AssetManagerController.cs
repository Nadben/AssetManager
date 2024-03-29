﻿using AssetManager.Application.Commands;
using AssetManager.Application.DTO;
using AssetManager.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace AssetManager.Api.Controllers;

[ApiController]
[Route("AssetManager/v1")]
public class AssetManagerController : ApiControllerBase
{
    private readonly ILogger<AssetManagerController> _logger;
    private readonly IMediator _mediator;

    public AssetManagerController(ILogger<AssetManagerController> logger,
        IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// this endpoint is used to get the Area created with its assigned Asset.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Area/{AreaId:guid}")]
    [ProducesResponseType(typeof(AreaDto), 200)]
    public Task<ActionResult<AreaDto>> Get([FromRoute] GetAreaQuery query)
    {
        return Send<GetAreaQuery, AreaDto>(query);
    }

    /// <summary>
    /// This endpoint is used to get the Asset created.
    /// </summary>
    /// <returns></returns>
    [HttpGet("Asset/{AssetId:guid}")]
    [ProducesResponseType(typeof(AssetDto), statusCode: 200)]
    public Task<ActionResult<AssetDto>> Get([FromRoute] GetAssetQuery query)
    {
        return Send<GetAssetQuery, AssetDto>(query);
    }
    
    /// <summary>
    /// this endpoint is used to create an Area.
    /// </summary>
    /// <returns></returns>
    [HttpPost("Create/Area")]
    public Task<ActionResult<ApiResponse>> Post([FromBody] CreateAreaCommand command)
    {
        return Send<CreateAreaCommand, ApiResponse>(command);
    }

    /// <summary>
    /// This endpoint is used to create an Asset.
    /// </summary>
    /// <returns></returns>
    [HttpPost("Create/Asset")]
    public async Task<ActionResult<ApiResponse>> Post([FromBody] CreateAssetCommand command)
    {
        return await Send<CreateAssetCommand, ApiResponse>(command);
    }

    /// <summary>
    /// this endpoint is used to assign an Asset to an Area.
    /// </summary>
    /// <returns></returns>
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPut("assign/Asset/{AssetId:guid}/area/{AreaId:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignAssetToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to assign an owner to an Area.
    /// </summary>
    /// <returns></returns>
    // [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPut("assign/area/{areaid:guid}/owner/{ownerid:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to Assign an owner to an Asset.
    /// </summary>
    /// <returns></returns>
    [HttpPut("assign/asset/{AssetId:guid}/owner/{ownerid:guid}")]
    public async Task<IActionResult> Put([FromBody] AssignOwnerToAssetCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to remove an asset from an area
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("remove/asset/{AssetId:guid}/area/{AreaId:guid}")]
    public async Task<IActionResult> Put([FromBody] RemoveAssetFromAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    /// <summary>
    /// This endpoint is used to remove multiple assets from an area
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("remove/assets/area/{AreaId:guid}")]
    public async Task<IActionResult> Put([FromBody] RemoveAssetsFromAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// This endpoint is used to delete an Area.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("delete/area/{AreaId}")]
    public async Task<IActionResult> Delete([FromBody] DeleteAreaCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    /// <summary>
    /// This endpoint is used to delete an Asset.
    /// </summary>
    /// <returns></returns>
    [HttpDelete("delete/asset/{AssetId}")]
    public async Task<IActionResult> Delete([FromBody] DeleteAssetCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}