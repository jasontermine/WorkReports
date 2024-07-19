using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AssignmentRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime dueDate { get; set; }
    }
}
