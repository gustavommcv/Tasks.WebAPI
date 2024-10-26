using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class UserTask
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        [Required]
        public string? Title { get; set; }

        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [StringLength(15)]
        public string? status { get; set; }
    }
}
