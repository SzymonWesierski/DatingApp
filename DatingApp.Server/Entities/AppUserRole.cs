using Microsoft.AspNetCore.Identity;

namespace DatingApp.Server.Entities
{
	public class AppUserRole : IdentityUserRole<int>
	{
		public AppUser User { get; set; }
		public AppRole Role { get; set; }
	}
}
