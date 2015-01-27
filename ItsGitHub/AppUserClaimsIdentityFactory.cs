using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ItsGitHub
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppUser, string>
    {
        public override async Task<ClaimsIdentity> CreateAsync(
            UserManager<AppUser, string> manager,
            AppUser user,
            string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.FullName));

            return identity;
        }
    }
}