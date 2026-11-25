using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Command.TxProduct;
using Services.Queries.TxProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendConnector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TxProductController : ControllerBase
    {
        protected readonly IMediator mediator;
        public TxProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("ExternalProperty")]
        public async Task<IActionResult> Post([FromForm] CreateExternalPropertyListCommand create, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(create, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("ExternalPropertyV2")]
        public async Task<IActionResult> PostV2([FromBody] CreateExternalPropertyListCommand create, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(create, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Status")]
        public async Task<IActionResult> Put([FromForm] UpdateTxProductStatusCommand update, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(update, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("ExternalProperty")]
        public async Task<IActionResult> Get([FromQuery] GetExternalPropertyListQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
