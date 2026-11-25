using Microsoft.AspNetCore.Identity;

namespace IdentityBasicEx.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
