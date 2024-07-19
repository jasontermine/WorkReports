using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EmployeeRequestDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, Range(1, 120)]
        public int Age { get; set; }
    }
}
