using Museek.Data;
using Microsoft.AspNetCore.Identity;

namespace Museek.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<MuseekUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<MuseekUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
