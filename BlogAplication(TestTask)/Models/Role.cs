using System.Collections.Generic;

namespace BlogAplication.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public List<User> Users { get; set; }
        public Roles()
        {
            Users = new List<User>();
        }
    }
}
