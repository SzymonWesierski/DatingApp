using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;
using DatingApp.Server.Extensions;
using DatingApp.Server.Helpers;
using DatingApp.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Server.Controllers
{
	[Authorize]
	public class LikesController : BaseApiController
	{
		private readonly IUserRepository _userRepository;
		private readonly ILikesRepository _likesRepository;

		public LikesController(IUserRepository userRepository, ILikesRepository likesRepository) 
		{
			_userRepository = userRepository;
			_likesRepository = likesRepository;
		}

		[HttpPost("{username}")]
		public async Task<ActionResult> AddLike(string username)
		{
			var sourceUserId = User.GetUserId();
			var likedUser = await _userRepository.GetUserByUsernameAsync(username);
			var sourcerUser = await _likesRepository.GetUserWithLikes(sourceUserId);

			if ( sourceUserId == null) return NotFound();

			if (sourcerUser.UserName == username) return BadRequest("You cannot like yourself");

			var userLike = await _likesRepository.GetUserLike(sourceUserId, likedUser.Id);

			if (userLike != null) return BadRequest("You already like this user");

			userLike = new UserLike
			{
				SourceUserId = sourceUserId,
				TargetUserId = likedUser.Id,
			};

			sourcerUser.LikedUsers.Add(userLike);

			if(await _userRepository.SaveAllAsync()) return Ok();

			return BadRequest("Faild to like user");
		}

		[HttpGet]
		public async Task<ActionResult<PagedList<LikeDto>>> GetUserLikes([FromQuery]LikesParams likesParams)
		{
			likesParams.UserId = User.GetUserId();

			var users = await _likesRepository.GetUserLikes(likesParams);

			Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage,
				users.PageSize, users.TotalCount, users.TotalPage));

			return Ok(users);
		}
	}
}
