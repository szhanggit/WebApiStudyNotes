using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TXCMediatR.Commands;
using TXCMediatR.Models;
using TXCMediatR.Queries;

namespace TXCMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiBaseController
    {
        public ProductController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {

        }

        [HttpGet]
        [Route("backupsku")]
        public async Task<IActionResult> Get([FromQuery] GetSKUBackupQuery query, CancellationToken cancellationToken)
        {
                var result = await mediator.Send(query, cancellationToken);
                return Ok(result);
        }

        [HttpPost]
        [Route("backupsku")]
        public async Task<IActionResult> Post([FromBody] InsertSKUBackupCommand update, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(update, cancellationToken);
            return Ok(1);
        }

        [HttpGet]
        [Route("ExternalProperty")]
        public async Task<IActionResult> Get([FromQuery] GetExternalPropertyListQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("Price")]
        public async Task<IActionResult> Get([FromQuery] GetTxProductPriceQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllSampleQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet()]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] GetSampleInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSampleCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByAcquirerId")]
        public async Task<IActionResult> Get([FromQuery] GetMerchantListByAcquirerIdQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductList")]
        public async Task<IActionResult> Get([FromQuery] GetProductListQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
