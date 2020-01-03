namespace BlogAplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public int? RoleId { get; set; }
        public Roles Role { get; set; }
    }
}
