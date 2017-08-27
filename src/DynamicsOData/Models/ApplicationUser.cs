using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DynamicsOData.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public static string AccessTokenClaimType = "AccessToken";

        public string AccessToken { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) 
            : base(userName)
        {
        }
    }
}
