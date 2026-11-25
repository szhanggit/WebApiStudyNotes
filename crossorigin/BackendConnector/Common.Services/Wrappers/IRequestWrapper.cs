using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Common.Domain;

namespace Common.Services.Wrappers
{
    public interface IRequestWrapper<T> : IRequest<Response<T>>
    {
    }
}
