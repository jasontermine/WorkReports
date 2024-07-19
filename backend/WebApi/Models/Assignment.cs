using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class Assignment
{
    [Key]    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid uuid { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime startDate { get; set; }

    [Required]
    public DateTime dueDate { get; set; }
}