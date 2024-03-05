using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingAppDAL.Model
{
    public class Training
    {
        [Required]
        [Key]
        public int TrainingId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int CreatorId { get; set; }
        public int? TeamId { get; set; }
    }
}
