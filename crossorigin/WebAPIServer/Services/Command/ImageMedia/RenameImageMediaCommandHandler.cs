using Common.Domain;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.ImageMedia
{
    public class RenameImageMediaCommandHandler : IRequestHandlerWrapper<RenameImageMediaCommand, int>
    {
        public RenameImageMediaCommandHandler()
        {

        }

        public async Task<Response<int>> Handle(RenameImageMediaCommand request, CancellationToken cancellationToken)
        {
            try
            {



                return Response.Fail("fail", 0);
            }
            catch (Exception e)
            {
                return Response.Fail<int>("Exception", 0);
            }
        }
    }
}
