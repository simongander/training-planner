using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

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
