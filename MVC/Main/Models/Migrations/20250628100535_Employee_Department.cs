using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Models.Migrations
{
    /// <inheritdoc />
    public partial class Employee_Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Tarek Mostafa", "Software Development" },
                    { 2, "Eng. Amal Fahmy", "Quality Assurance" },
                    { 3, "Mr. Hesham Magdy", "IT Operations" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "DepartmentId", "ImageUrl", "JobTitle", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, null, "Software Engineer", "Ali Mahmoud", 6000 },
                    { 2, "Alexandria", 2, null, "QA Engineer", "Sara Ahmed", 7500 },
                    { 3, "Cairo", 1, null, "Project Manager", "Mohamed Nabil", 8000 },
                    { 4, "Giza", 3, null, "UI/UX Designer", "Yasmin Fathy", 5500 },
                    { 5, "6th October", 2, null, "DevOps Engineer", "Omar Khaled", 9000 },
                    { 6, "Mansoura", 3, null, "Database Administrator", "Mona Samir", 6700 },
                    { 7, "Cairo", 1, null, "Backend Developer", "Khaled Hussein", 6200 },
                    { 8, "Helwan", 1, null, "Frontend Developer", "Laila Gamal", 5800 },
                    { 9, "Zagazig", 2, null, "System Analyst", "Tamer Ali", 7200 },
                    { 10, "Fayoum", 3, null, "Support Engineer", "Nour Hassan", 6300 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
