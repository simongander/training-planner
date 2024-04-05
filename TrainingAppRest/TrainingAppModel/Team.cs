using System.ComponentModel.DataAnnotations;

namespace TrainingAppModel
{
    public class Team
    {
        [Required]
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
    }
}
