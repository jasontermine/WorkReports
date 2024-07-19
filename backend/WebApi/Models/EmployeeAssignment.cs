using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class EmployeeAssignment
    {
        [Key]    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public Guid EmployeeUuid { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }

        [Required]
        [ForeignKey("Assignment")]
        public Guid AssignmentUuid { get; set; }

        [JsonIgnore]
        public Assignment Assignment { get; set; }

        [Required]
        [Range(0, 999.99)]
        public float HoursWorked { get; set; }

        [Required]
        public DateTime RecordedAt { get; set; }
    }
}
