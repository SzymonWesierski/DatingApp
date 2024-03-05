using System.Security.Claims;

namespace DatingApp.Server.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static string GetUsername(this ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}
	}
}
