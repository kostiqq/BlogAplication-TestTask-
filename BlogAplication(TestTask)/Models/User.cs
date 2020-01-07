using Microsoft.AspNetCore.Identity;

namespace BlogAplication.Models
{
    public class User : IdentityUser
    {
        public int? RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
