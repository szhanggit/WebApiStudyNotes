using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;
using TXCMediatR.Queries;

namespace TXCMediatR.Queries
{
    public class GetAllSampleQueryHandler : IRequestHandlerWrapper<GetAllSampleQuery, IEnumerable<SampleInfoModel>>
    {



        public async Task<Response<IEnumerable<SampleInfoModel>>> Handle(GetAllSampleQuery request, CancellationToken cancellationToken)
        {

            var data = new List<SampleInfoModel>()
            {
                new SampleInfoModel()
                {
                    UserInfoId = 1,
                    UserId = "homerio",
                    UserName = $"homerio {request.UserId}",
                    Email = "h.r.sumabat@gmail.com"
                },
                new SampleInfoModel()
                {
                    UserInfoId = 2,
                    UserId = "emsi",
                    UserName = "emsi_homer",
                    Email = "emsi@gmail.com"
                }
            };

            var result = await Task.FromResult(Response.Success<IEnumerable<SampleInfoModel>>("Successfully retrieve", data));
            return result;
        }
    }
}
