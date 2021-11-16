namespace Accommodation.Infrastructure.Identity
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using IdentityModel;
    using IdentityServer4.Models;
    using IdentityServer4.Services;
    using Microsoft.AspNetCore.Identity;

    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _UserManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _UserManager.GetUserAsync(context.Subject);

            IList<string> roles = await _UserManager.GetRolesAsync(user);

            IList<Claim> roleClaims = new List<Claim>();
            foreach (string role in roles)
            {
                roleClaims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            context.IssuedClaims.AddRange(roleClaims);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
