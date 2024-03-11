using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;
using DatingApp.Server.Helpers;

namespace DatingApp.Server.Interfaces
{
	public interface ILikesRepository
	{
		Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
		Task<AppUser> GetUserWithLikes(int userId);
		Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
	};
}
