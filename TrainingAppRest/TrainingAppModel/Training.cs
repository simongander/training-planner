using System;
using System.ComponentModel.DataAnnotations;

namespace TrainingAppModel
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
