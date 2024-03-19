using DatingApp.Server.Extensions;
using DatingApp.Server.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DatingApp.Server.Helpers
{
	public class LogUsersActivity : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var resultContext = await next();

			if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

			var uid = resultContext.HttpContext.User.GetUserId();

			var uow = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
			var user = await uow.UserRepository.GetUserByIdAsync(uid);
			user.LastActive = DateTime.UtcNow;
			await uow.Complete();
		}
	}
}
