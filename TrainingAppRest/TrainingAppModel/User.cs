using System.ComponentModel.DataAnnotations;

namespace TrainingAppModel
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
