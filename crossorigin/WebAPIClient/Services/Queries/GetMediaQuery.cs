using Common.Domain.Dto;
using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{
    public class GetMediaQuery : IRequestWrapper<MediaDto>
    {
        public int MediaId { get; set; }
    }
}
