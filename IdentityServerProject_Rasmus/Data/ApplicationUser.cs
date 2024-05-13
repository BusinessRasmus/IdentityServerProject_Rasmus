using Microsoft.AspNetCore.Identity;

namespace IdentityServerProject_Rasmus.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationUser User { get; set; }

        public virtual ApplicationRole Role { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> Roles { get; set; }
    }

}
