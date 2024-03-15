﻿using Microsoft.AspNetCore.Identity;

namespace DatingApp.Server.Entities
{
	public class AppRole : IdentityRole<int>
	{
		public ICollection<AppUserRole> UserRoles { get; set; }
	}
}
