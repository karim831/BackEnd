using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task.Models.Migrations
{
    /// <inheritdoc />
    public partial class MVCTaskInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxDegree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CRSResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    CRSId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRSResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    CRSId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CRSResults",
                columns: new[] { "Id", "CRSId", "Degree", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1, 85, 1 },
                    { 2, 2, 78, 1 },
                    { 3, 3, 90, 2 },
                    { 4, 4, 65, 3 },
                    { 5, 5, 92, 4 },
                    { 6, 1, 88, 5 },
                    { 7, 2, 74, 2 },
                    { 8, 3, 81, 3 },
                    { 9, 4, 59, 4 },
                    { 10, 5, 95, 5 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DeptId", "Hours", "MaxDegree", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 1, 3, 100, 50, "Math" },
                    { 2, 1, 4, 100, 45, "Physics" },
                    { 3, 2, 3, 100, 50, "Chemistry" },
                    { 4, 3, 5, 100, 60, "Programming" },
                    { 5, 3, 4, 100, 50, "Networks" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "ManagerName", "Name" },
                values: new object[,]
                {
                    { 1, "Dr. Nader", "Computer Science" },
                    { 2, "Dr. Laila", "Physics" },
                    { 3, "Dr. Amin", "Chemistry" },
                    { 4, "Dr. Safaa", "Mathematics" },
                    { 5, "Dr. Tamer", "Networks" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CRSId", "DeptId", "Image", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 1, "ahmed.png", "Ahmed Samir", 15000 },
                    { 2, "Giza", 2, 1, "sara.png", "Sara Hany", 14000 },
                    { 3, "Alex", 3, 2, null, "Tamer Youssef", 16000 },
                    { 4, "Mansoura", 4, 3, "nourhan.png", "Nourhan Taha", 14500 },
                    { 5, null, null, 5, null, "Hossam Reda", 13000 }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "DeptId", "Grade", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", 1, 85, "ali.png", "Ali Hassan" },
                    { 2, "Giza", 1, 92, "mona.png", "Mona Gamal" },
                    { 3, "Alex", 2, 78, null, "Ibrahim Said" },
                    { 4, "Mansoura", 3, 88, "reem.jpg", "Reem Adel" },
                    { 5, null, 3, 73, null, "Tarek Helmy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CRSResults");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");
        }
    }
}
