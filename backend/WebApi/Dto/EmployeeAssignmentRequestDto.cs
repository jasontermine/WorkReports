using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EmployeeAssignmentRequestDto
    {
        [Required]
        public Guid EmployeeUuid { get; set; }

        [Required]
        public Guid AssignmentUuid { get; set; }

        [Required]
        [Range(0, 999.99)]
        public float HoursWorked { get; set; }

        public DateTime RecordedAt { get; set; }
    }
}
