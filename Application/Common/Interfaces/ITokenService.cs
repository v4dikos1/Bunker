using System.Security.Claims;
using Application.Users;

namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user, List<Claim> claims);
    }
}
