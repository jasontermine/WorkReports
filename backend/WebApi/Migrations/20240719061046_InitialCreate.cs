using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.uuid);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentUuid = table.Column<Guid>(type: "uuid", nullable: false),
                    HoursWorked = table.Column<float>(type: "real", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_Assignments_AssignmentUuid",
                        column: x => x.AssignmentUuid,
                        principalTable: "Assignments",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAssignments_Employees_EmployeeUuid",
                        column: x => x.EmployeeUuid,
                        principalTable: "Employees",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "uuid", "Name", "dueDate", "startDate" },
                values: new object[,]
                {
                    { new Guid("119c7f18-bb17-4eaa-99ac-272916db5b43"), "Murtenstrasse 5", new DateTime(2024, 6, 30, 23, 59, 59, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("19eebcc1-0d83-4ee7-af6e-8f2aa539311f"), "Schanzenweg 8", new DateTime(2024, 12, 31, 23, 59, 59, 0, DateTimeKind.Utc), new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f2861230-88c0-4677-a7ca-96197ec62344"), "Könizstrasse 12", new DateTime(2024, 8, 31, 23, 59, 59, 0, DateTimeKind.Utc), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "uuid", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("075820e6-e72d-464b-bd3f-78f006e8adea"), 27, "Sophia", "Davis" },
                    { new Guid("3abb9fc0-4343-4426-bdc1-d2c103914df3"), 29, "James", "Brown" },
                    { new Guid("4d9b98ea-a12b-4b59-a230-682346c34d7b"), 28, "William", "Williams" },
                    { new Guid("57be1f8f-f483-423f-9821-2b380fc3ab45"), 30, "John", "Doe" },
                    { new Guid("5fc099aa-42cc-412a-a8d3-a06914a9e7d1"), 40, "Michael", "Smith" },
                    { new Guid("ace76463-1fad-4d80-b083-e00b0fe04eac"), 31, "Liam", "Miller" },
                    { new Guid("adc24da7-6fdb-4aa0-8551-87b453afb62f"), 32, "Olivia", "Johnson" },
                    { new Guid("bc134cd6-9f96-4cb0-b053-f3ca56160f1f"), 25, "Anna", "Karelia" },
                    { new Guid("cc6b6b10-12ef-41b5-ad18-72e5fb671714"), 35, "Emily", "Jones" },
                    { new Guid("d29c17f5-6232-4042-8d5f-7c8994711a8b"), 26, "Ava", "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAssignments",
                columns: new[] { "Id", "AssignmentUuid", "EmployeeUuid", "HoursWorked", "RecordedAt" },
                values: new object[,]
                {
                    { 1, new Guid("119c7f18-bb17-4eaa-99ac-272916db5b43"), new Guid("57be1f8f-f483-423f-9821-2b380fc3ab45"), 40f, new DateTime(2024, 1, 15, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new Guid("119c7f18-bb17-4eaa-99ac-272916db5b43"), new Guid("bc134cd6-9f96-4cb0-b053-f3ca56160f1f"), 35f, new DateTime(2024, 1, 16, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new Guid("119c7f18-bb17-4eaa-99ac-272916db5b43"), new Guid("5fc099aa-42cc-412a-a8d3-a06914a9e7d1"), 30f, new DateTime(2024, 1, 17, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new Guid("19eebcc1-0d83-4ee7-af6e-8f2aa539311f"), new Guid("cc6b6b10-12ef-41b5-ad18-72e5fb671714"), 45f, new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, new Guid("19eebcc1-0d83-4ee7-af6e-8f2aa539311f"), new Guid("3abb9fc0-4343-4426-bdc1-d2c103914df3"), 50f, new DateTime(2024, 7, 15, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, new Guid("19eebcc1-0d83-4ee7-af6e-8f2aa539311f"), new Guid("adc24da7-6fdb-4aa0-8551-87b453afb62f"), 20f, new DateTime(2024, 7, 20, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, new Guid("f2861230-88c0-4677-a7ca-96197ec62344"), new Guid("4d9b98ea-a12b-4b59-a230-682346c34d7b"), 25f, new DateTime(2024, 3, 15, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, new Guid("f2861230-88c0-4677-a7ca-96197ec62344"), new Guid("075820e6-e72d-464b-bd3f-78f006e8adea"), 30f, new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, new Guid("f2861230-88c0-4677-a7ca-96197ec62344"), new Guid("ace76463-1fad-4d80-b083-e00b0fe04eac"), 40f, new DateTime(2024, 3, 25, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, new Guid("f2861230-88c0-4677-a7ca-96197ec62344"), new Guid("d29c17f5-6232-4042-8d5f-7c8994711a8b"), 15f, new DateTime(2024, 3, 30, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignments_AssignmentUuid",
                table: "EmployeeAssignments",
                column: "AssignmentUuid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAssignments_EmployeeUuid",
                table: "EmployeeAssignments",
                column: "EmployeeUuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAssignments");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
