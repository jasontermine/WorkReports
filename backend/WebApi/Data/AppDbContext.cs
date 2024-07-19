using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var employeeIds = new Guid[]
            {
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                Guid.NewGuid(), Guid.NewGuid()
            };

            modelBuilder.Entity<Employee>().HasData(
                new Employee { uuid = employeeIds[0], FirstName = "John", LastName = "Doe", Age = 30 },
                new Employee { uuid = employeeIds[1], FirstName = "Anna", LastName = "Karelia", Age = 25 },
                new Employee { uuid = employeeIds[2], FirstName = "Michael", LastName = "Smith", Age = 40 },
                new Employee { uuid = employeeIds[3], FirstName = "Emily", LastName = "Jones", Age = 35 },
                new Employee { uuid = employeeIds[4], FirstName = "James", LastName = "Brown", Age = 29 },
                new Employee { uuid = employeeIds[5], FirstName = "Olivia", LastName = "Johnson", Age = 32 },
                new Employee { uuid = employeeIds[6], FirstName = "William", LastName = "Williams", Age = 28 },
                new Employee { uuid = employeeIds[7], FirstName = "Sophia", LastName = "Davis", Age = 27 },
                new Employee { uuid = employeeIds[8], FirstName = "Liam", LastName = "Miller", Age = 31 },
                new Employee { uuid = employeeIds[9], FirstName = "Ava", LastName = "Wilson", Age = 26 }
            );

            var assignmentIds = new Guid[]
            {
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
            };

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment { uuid = assignmentIds[0], Name = "Murtenstrasse 5", startDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc), dueDate = new DateTime(2024, 6, 30, 23, 59, 59, DateTimeKind.Utc) },
                new Assignment { uuid = assignmentIds[1], Name = "Schanzenweg 8", startDate = new DateTime(2024, 7, 1, 0, 0, 0, DateTimeKind.Utc), dueDate = new DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc) },
                new Assignment { uuid = assignmentIds[2], Name = "Könizstrasse 12", startDate = new DateTime(2024, 3, 1, 0, 0, 0, DateTimeKind.Utc), dueDate = new DateTime(2024, 8, 31, 23, 59, 59, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<EmployeeAssignment>().HasData(
                new EmployeeAssignment { Id = 1, EmployeeUuid = employeeIds[0], AssignmentUuid = assignmentIds[0], HoursWorked = 40, RecordedAt = new DateTime(2024, 1, 15, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 2, EmployeeUuid = employeeIds[1], AssignmentUuid = assignmentIds[0], HoursWorked = 35, RecordedAt = new DateTime(2024, 1, 16, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 3, EmployeeUuid = employeeIds[2], AssignmentUuid = assignmentIds[0], HoursWorked = 30, RecordedAt = new DateTime(2024, 1, 17, 12, 0, 0, DateTimeKind.Utc) },

                new EmployeeAssignment { Id = 4, EmployeeUuid = employeeIds[3], AssignmentUuid = assignmentIds[1], HoursWorked = 45, RecordedAt = new DateTime(2024, 7, 10, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 5, EmployeeUuid = employeeIds[4], AssignmentUuid = assignmentIds[1], HoursWorked = 50, RecordedAt = new DateTime(2024, 7, 15, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 6, EmployeeUuid = employeeIds[5], AssignmentUuid = assignmentIds[1], HoursWorked = 20, RecordedAt = new DateTime(2024, 7, 20, 12, 0, 0, DateTimeKind.Utc) },

                new EmployeeAssignment { Id = 7, EmployeeUuid = employeeIds[6], AssignmentUuid = assignmentIds[2], HoursWorked = 25, RecordedAt = new DateTime(2024, 3, 15, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 8, EmployeeUuid = employeeIds[7], AssignmentUuid = assignmentIds[2], HoursWorked = 30, RecordedAt = new DateTime(2024, 3, 20, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 9, EmployeeUuid = employeeIds[8], AssignmentUuid = assignmentIds[2], HoursWorked = 40, RecordedAt = new DateTime(2024, 3, 25, 12, 0, 0, DateTimeKind.Utc) },
                new EmployeeAssignment { Id = 10, EmployeeUuid = employeeIds[9], AssignmentUuid = assignmentIds[2], HoursWorked = 15, RecordedAt = new DateTime(2024, 3, 30, 12, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
