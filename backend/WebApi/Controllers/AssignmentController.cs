using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            var assignments = await _context.Assignments.ToListAsync();

            return Ok(assignments);
        }

        [HttpGet("{id}", Name = "GetAssignment")]
        public async Task<ActionResult<Assignment>> GetAssignment(Guid id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        [HttpPost]
        public async Task<ActionResult<Assignment>> PostAssignment(AssignmentRequestDto assignmentRequestDto)
        {
            var assignment = new Assignment
            {
                uuid = Guid.NewGuid(),
                Name = assignmentRequestDto.Name,
                startDate = assignmentRequestDto.startDate,
                dueDate = assignmentRequestDto.dueDate
            };

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssignment), new { id = assignment.uuid }, assignment);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(Guid id, Assignment assignment)
        {
            if (id != assignment.uuid)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
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
        public async Task<IActionResult> DeleteAssignment(Guid id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssignmentExists(Guid id)
        {
            return _context.Assignments.Any(e => e.uuid == id);
        }
    }
}
