using market.Domain.Const;
using market.Domain.DataEntities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace market.Host.Areas.Identity.Factory
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserEntity>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<UserEntity> userManager,
            IOptions<IdentityOptions> options
            ) : base(userManager, options)
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserEntity user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim(ClaimTypes.Role, user.UserType.ToString()));
           // identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));


            return identity;
        }
    }
}
