using Common.Domain;
using Common.Domain.Models.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Wrappers
{
    public interface IRequestListHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, Response<TOut>>
         where TIn : IRequestListWrapper<TOut>
         where TOut : IPaginationTotal
    {

    }
}
