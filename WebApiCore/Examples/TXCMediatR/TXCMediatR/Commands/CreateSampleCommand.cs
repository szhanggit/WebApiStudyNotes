using TXC.Common.Services;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Commands
{
    public class CreateSampleCommand : BaseRequest, IRequestWrapper<SampleInfoModel>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
