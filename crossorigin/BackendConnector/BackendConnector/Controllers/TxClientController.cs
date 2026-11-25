using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Queries.TxClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendConnector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TxClientController : ControllerBase
    {
        protected readonly IMediator mediator;
        public TxClientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTxClientListQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get([FromQuery] GetTxClientByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetByIdentityCode")]
        public async Task<IActionResult> Get([FromQuery] GetTxClientByIdentityCodeQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateTxClientRequest query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] UpdateTxClientRequest query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
