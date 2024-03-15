using DatingApp.Server.Entities;

namespace DatingApp.Server.Interfaces
{
    public interface ITokenService
    {
		Task<string> CreateToken(AppUser user);
    }
}