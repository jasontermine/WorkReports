using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeAssignmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAssignment>>> GetEmployeeAssignments()
        {
            var employeeAssignments = await _context.EmployeeAssignments.ToListAsync();

            return Ok(employeeAssignments.Select(p => new
            {
                Id = p.Id,
                EmployeeUuid = p.EmployeeUuid,
                AssignmentUuid = p.AssignmentUuid,
                HoursWorked = p.HoursWorked,
                RecordedAt = p.RecordedAt
            }));
        }

        [HttpGet("{id}", Name = "GetEmployeeAssignmentById")]
        public async Task<ActionResult<EmployeeAssignment>> GetEmployeeAssignment(int id)
        {
            var employeeAssignment = await _context.EmployeeAssignments.FindAsync(id);

            if (employeeAssignment == null)
            {
                return NotFound();
            }

            return employeeAssignment;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAssignment>> PostEmployeeAssignment(EmployeeAssignmentRequestDto employeeAssignmentDto)
        {
            var employeeAssignment = new EmployeeAssignment
            {
                EmployeeUuid = employeeAssignmentDto.EmployeeUuid,
                AssignmentUuid = employeeAssignmentDto.AssignmentUuid,
                HoursWorked = employeeAssignmentDto.HoursWorked,
                RecordedAt = DateTime.UtcNow
            };

            _context.EmployeeAssignments.Add(employeeAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeAssignment), new { id = employeeAssignment.Id }, employeeAssignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeAssignment(int id, EmployeeAssignmentRequestDto employeeAssignmentDto)
        {
            var existingAssignment = await _context.EmployeeAssignments.FindAsync(id);
            if (existingAssignment == null)
            {
                return NotFound();
            }

            existingAssignment.EmployeeUuid = employeeAssignmentDto.EmployeeUuid;
            existingAssignment.AssignmentUuid = employeeAssignmentDto.AssignmentUuid;
            existingAssignment.HoursWorked = employeeAssignmentDto.HoursWorked;
            if (employeeAssignmentDto.RecordedAt != default)
            {
                existingAssignment.RecordedAt = employeeAssignmentDto.RecordedAt;
            }

            _context.Entry(existingAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAssignment(int id)
        {
            var employeeAssignment = await _context.EmployeeAssignments.FindAsync(id);
            if (employeeAssignment == null)
            {
                return NotFound();
            }

            _context.EmployeeAssignments.Remove(employeeAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeAssignmentExists(int id)
        {
            return _context.EmployeeAssignments.Any(e => e.Id == id);
        }
    }
}
