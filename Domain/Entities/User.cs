using System.ComponentModel.DataAnnotations;

namespace TaskList_BusinessBooster.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
