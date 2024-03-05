using System.ComponentModel.DataAnnotations;

namespace TrainingAppDAL.Model
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
