using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingAppDAL.Model
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
