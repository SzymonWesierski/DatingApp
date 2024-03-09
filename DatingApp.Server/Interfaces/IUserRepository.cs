using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;
using DatingApp.Server.Helpers;

namespace DatingApp.Server.Interfaces
{
	public interface IUserRepository
	{
		void Update(AppUser user);
		Task<bool> SaveAllAsync();
		Task<IEnumerable<AppUser>> GetUsersAsync();
		Task<AppUser> GetUserByIdAsync(int id);
		Task<AppUser> GetUserByUsernameAsync(string username);
		Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
		Task<MemberDto> GetMemberByNameAsync(string username);
	}
}
