using market.Data.Context;
using market.Domain.DataEntities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace market.Host.Controllers
{

    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountController(AppDBContext appDBContext, SignInManager<UserEntity> signInManager)
        {
            _context = appDBContext;
            _signInManager = signInManager;
        }

        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {

            //var email = User.Identity.GetClaimsByType().Select(x => x.Value).FirstOrDefault().ToString();

            UserEntity entityUser = _context.Users.ToList().FirstOrDefault(x => x.UserName == User.Identities.FirstOrDefault().Claims.ToList().FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);

            var a = HttpContext;

            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(entityUser, true, "Google");

            //var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            /*var claims = result.Principal.Identities.FirstOrDefault()
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });*/

            return RedirectToAction("Index", "Home"); //Json(claims);
        }
    }
}
