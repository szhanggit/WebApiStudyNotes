using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Command.ImageMedia;
using Services.Queries.ImageMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ApiBaseController
    {
        public MediaController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetImageMediaListQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(RenameImageMediaCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] GetMediaQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
