using AssetManager.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Api.Controllers
{
    public abstract class ApiControllerBase :  Controller
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async virtual Task<ActionResult<TApiResult>> Send<TApiParameter, TApiResult>(TApiParameter apiParameter)
            where TApiParameter : IRequest
            where TApiResult : ApiResponse
        {
            try
            {
                var result = await _mediator.Send(apiParameter);

                if(HttpContext.Request.Method == "POST")
                {
                    return CreatedAtAction(HttpContext.Request.Method, new { id = result }, apiParameter);
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}