using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;

namespace DatingApp.Server.Interfaces
{
	public interface IUserRepository
	{
		void Update(AppUser user);
		Task<bool> SaveAllAsync();
		Task<IEnumerable<AppUser>> GetUsersAsync();
		Task<AppUser> GetUserByIdAsync(int id);
		Task<AppUser> GetUserByUsernameAsync(string username);
		Task<IEnumerable<MemberDto>> GetMembersAsync();
		Task<MemberDto> GetMemberByNameAsync(string username);
	}
}
