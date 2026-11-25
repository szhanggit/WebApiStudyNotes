using TXC.Common.Services;
using TXC.Common.Services.Wrappers;
using TXCMediatR.Models;

namespace TXCMediatR.Queries
{
    public class GetAllSampleQuery : BaseRequest, IRequestWrapper<IEnumerable<SampleInfoModel>>
    {
    }
}
