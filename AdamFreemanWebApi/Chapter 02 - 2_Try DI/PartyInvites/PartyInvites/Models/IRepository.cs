using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public interface IRepository
    {
        void Add(GuestResponse newResponse);
        IEnumerable<GuestResponse> Responses { get; }

    }
}
