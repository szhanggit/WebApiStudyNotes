using MediatR;
using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;
using TXCMediatR.Queries;

namespace TXCMediatR.Queries
{
    public class GetSampleInfoQueryHandler : IRequestHandlerWrapper<GetSampleInfoQuery, SampleInfoModel>
    {
        private readonly IMediator _mediator;
        private readonly GetAllSampleQueryHandler getAllUsersQueryHandler;
        public GetSampleInfoQueryHandler(IMediator mediator)
        {
            getAllUsersQueryHandler = new GetAllSampleQueryHandler();
            _mediator = mediator;
        }
        public async Task<Response<SampleInfoModel>> Handle(GetSampleInfoQuery request, CancellationToken cancellationToken)
        {
            //var allUsers = (await getAllUsersQueryHandler.Handle(new GetAllSampleQuery(), cancellationToken)).Data.ToList();
            var allUsers = await _mediator.Send(new GetAllSampleQuery(), cancellationToken);

            var result = allUsers.Data.FirstOrDefault(f => f.UserId == request.UserId);
            if (result != null)
            {
                return Response.Success("Successfully retrieve", result);
            }
            else
            {
                return Response.Success("Successfully retrieve", result);
            }
        }
    }
}
