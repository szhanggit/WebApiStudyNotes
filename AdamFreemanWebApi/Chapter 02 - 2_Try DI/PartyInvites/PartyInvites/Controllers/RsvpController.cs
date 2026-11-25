using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class RsvpController : ApiController
    {
        IRepository repo;
        public RsvpController(IRepository repoImpl)
        {
            repo = repoImpl;
        }
        /*http://localhost:37993/api/rsvp*/
        public IEnumerable<GuestResponse> GetAttendees()
        {
            return repo.Responses.Where(x => x.WillAttend == true);
        }

        public void PostResponse(GuestResponse response)
        {
            if (ModelState.IsValid)
            {
                repo.Add(response);
            }
        }
    }
}
