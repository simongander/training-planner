using System.ComponentModel.DataAnnotations;

namespace TrainingAppModel
{
    public class TeamMembership
    {
        [Required]
        [Key]
        public int MembershipId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
