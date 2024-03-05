using System.ComponentModel.DataAnnotations;

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
