using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class CourseImage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int? ImageOrder { get; set; } 
        public Course Course { get; set; }
    }
}