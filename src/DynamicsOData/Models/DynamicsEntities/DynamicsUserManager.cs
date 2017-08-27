using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DynamicsOData.Models.DynamicsEntities
{
    public class DynamicsSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private AuthenticationManager authenticationManager;

        public DynamicsSignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            var context = contextAccessor.HttpContext;
            this.authenticationManager = context.Authentication;
        }

        public override async Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
        {
            var applicationUser = user as ApplicationUser;

            var scheme = authenticationManager.GetAuthenticationSchemes().First().AuthenticationScheme;

            var claim = await this.ClaimsFactory.CreateAsync(user);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim.Identity.AuthenticationType);
            claimsIdentity.AddClaims(claim.Claims);
            claimsIdentity.AddClaim(new Claim(ApplicationUser.AccessTokenClaimType, applicationUser.AccessToken));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await authenticationManager.SignOutAsync(scheme);
            await authenticationManager.SignInAsync(scheme, claimsPrincipal, new AuthenticationProperties() { IsPersistent = false });
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            try
            {
                string resource = "https://dfmd365-435136c823696c72eaos.cloudax.dynamics.com";
                string tenant = "https://login.windows.net/dynamicsformembership.onmicrosoft.com";
                string clientId = "8eb86713-9b96-42a4-93ab-ad0e761c9327";

                var userCredenctial = new UserCredential(userName, password);

                AuthenticationContext authContext = new AuthenticationContext(tenant);
                AuthenticationResult authenticationResult = await authContext.AcquireTokenAsync(resource, clientId, userCredenctial);

                var user = new ApplicationUser {
                    AccessToken = authenticationResult.AccessToken,
                    UserName = userName,
                    Email = userName,
                    Id = authenticationResult.UserInfo.UniqueId,
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    NormalizedEmail = userName,
                    NormalizedUserName = userName,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    PhoneNumber = "",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = authenticationResult.UserInfo.UniqueId,
                    ConcurrencyStamp = authenticationResult.UserInfo.UniqueId
                };

                user.Claims.Add(new IdentityUserClaim<string>()
                {
                    ClaimType = ClaimTypes.Name,
                    ClaimValue = user.UserName,
                    UserId = user.Id
                });

                user.Claims.Add(new IdentityUserClaim<string>()
                {
                    ClaimType = ApplicationUser.AccessTokenClaimType,
                    ClaimValue = authenticationResult.AccessToken,
                    UserId = user.Id
                });

                user.Claims.Add(new IdentityUserClaim<string>()
                {
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = user.UserName,
                    UserId = user.Id
                });

                user.Roles.Add(new IdentityUserRole<string>() { RoleId = "AxUser", UserId = user.Id });

                var tuser = user as TUser;

                await this.SignInAsync(tuser, true);

                return SignInResult.Success;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
