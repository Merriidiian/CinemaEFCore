using Microsoft.AspNetCore.Identity;

namespace MoviesApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}