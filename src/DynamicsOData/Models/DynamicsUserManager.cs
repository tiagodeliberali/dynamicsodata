using DynamicsOData.Models.DynamicsEntities;
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

namespace DynamicsOData.Models
{
    public class DynamicsSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private AuthenticationManager authenticationManager;
        private ODataOptions odataOptions;

        public DynamicsSignInManager(UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger, IOptions<ODataOptions> odataOptions) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {
            var context = contextAccessor.HttpContext;
            this.authenticationManager = context.Authentication;
            this.odataOptions = odataOptions.Value;
        }

        public override async Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
        {
            var applicationUser = user as ApplicationUser;

            var scheme = authenticationManager.GetAuthenticationSchemes().First().AuthenticationScheme;

            var claim = await this.ClaimsFactory.CreateAsync(user);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity("Identity.Application");
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
                var userCredenctial = new UserCredential(userName, password);

                AuthenticationContext authContext = new AuthenticationContext(odataOptions.Tenant);
                AuthenticationResult authenticationResult = await authContext.AcquireTokenAsync(odataOptions.Resource, odataOptions.ClientId, userCredenctial);

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

                user.Roles.Add(new IdentityUserRole<string>() { RoleId = "AxUser", UserId = user.Id });

                var tuser = user as TUser;

                await this.SignInAsync(tuser, true);

                return SignInResult.Success;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
