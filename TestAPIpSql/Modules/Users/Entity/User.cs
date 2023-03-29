using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPISql.Modules.Users.Entity
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
