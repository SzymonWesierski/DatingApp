using DatingApp.Server.Entities;

namespace DatingApp.Server.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}