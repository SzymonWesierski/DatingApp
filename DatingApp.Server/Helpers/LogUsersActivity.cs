﻿using DatingApp.Server.Extensions;
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

			var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
			var user = await repo.GetUserByIdAsync(int.Parse(uid));
			user.LastActive = DateTime.UtcNow;
			await repo.SaveAllAsync();
		}
	}
}
