using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingAppDAL.Model
{
    public class TrainingType
    {
        [Required]
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageName { get; set; }
    }
}
