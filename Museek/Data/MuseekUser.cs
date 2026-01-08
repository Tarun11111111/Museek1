using Microsoft.AspNetCore.Identity;

namespace Museek.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class MuseekUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }  
}
