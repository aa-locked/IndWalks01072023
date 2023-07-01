using Microsoft.AspNetCore.Identity;

namespace IndWalks.API.Repository.UserAUth
{
    public interface IUserAuthJwtRepository
    {
        string CreateJWTToken(IdentityUser identityUser, List<string> roles);
    }
}
