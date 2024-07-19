using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var employees = await _context.Employees.ToListAsync();
        
        if (employees == null)
        {
            return NotFound();
        }

        return Ok(employees.ToList().Select(p => new
        {
            uuid = p.uuid,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Age = p.Age
        }));
    }

    [HttpGet("{id}", Name = "GetEmployee")]
    public async Task<ActionResult<Employee>> GetEmployee(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }


    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee(EmployeeRequestDto employeeRequestDto)
    {
        var employee = new Employee
        {
            uuid = Guid.NewGuid(),
            FirstName = employeeRequestDto.FirstName,
            LastName = employeeRequestDto.LastName,
            Age = employeeRequestDto.Age
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmployee), new { id = employee.uuid }, employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
    {
        if (id != employee.uuid)
        {
            return BadRequest();
        }

        _context.Entry(employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id))
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
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeeExists(Guid id)
    {
        return _context.Employees.Any(e => e.uuid == id);
    }
}