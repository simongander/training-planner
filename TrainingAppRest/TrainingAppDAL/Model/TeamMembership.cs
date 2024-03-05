using System.ComponentModel.DataAnnotations;

namespace TrainingAppDAL.Model
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
