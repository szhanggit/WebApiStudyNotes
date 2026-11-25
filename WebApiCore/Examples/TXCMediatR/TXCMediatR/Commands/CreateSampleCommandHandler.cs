using TXC.Common.Domain;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;
using TXCMediatR.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace TXCMediatR.Commands
{
    public class CreateSampleCommandHandler : IRequestHandlerWrapper<CreateSampleCommand, SampleInfoModel>
    {
        private readonly GetAllSampleQueryHandler getAllUsersQueryHandler;
        public CreateSampleCommandHandler()
        {
            getAllUsersQueryHandler = new GetAllSampleQueryHandler();
        }
        public async Task<Response<SampleInfoModel>> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
        {
            var allUsers = (await getAllUsersQueryHandler.Handle(new GetAllSampleQuery(), cancellationToken)).Data.ToList();
            var newUser = new SampleInfoModel
            {
                UserInfoId = allUsers.Max(m => m.UserInfoId) + 1,
                UserName = request.UserName,
                Email = request.Email
            };
            allUsers.Add(newUser);


            return Response.Success("New user successfully added", newUser);
        }
    }
}
