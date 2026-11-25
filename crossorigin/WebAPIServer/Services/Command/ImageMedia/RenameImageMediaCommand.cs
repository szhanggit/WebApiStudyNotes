using Common.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.ImageMedia
{
    public class RenameImageMediaCommand : IRequestWrapper<int>
    {
        public int MediaId { get; set; }
        public string Keyword { get; set; }
    }
}
