using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.Models.Migrations
{
    /// <inheritdoc />
    public partial class MVCTaskAddRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DeptId",
                table: "Trainees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CRSId",
                table: "Instructors",
                column: "CRSId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_CRSResults_CRSId",
                table: "CRSResults",
                column: "CRSId");

            migrationBuilder.CreateIndex(
                name: "IX_CRSResults_TraineeId",
                table: "CRSResults",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRSResults_Courses_CRSId",
                table: "CRSResults",
                column: "CRSId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CRSResults_Trainees_TraineeId",
                table: "CRSResults",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CRSId",
                table: "Instructors",
                column: "CRSId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DeptId",
                table: "Instructors",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptId",
                table: "Trainees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CRSResults_Courses_CRSId",
                table: "CRSResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CRSResults_Trainees_TraineeId",
                table: "CRSResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CRSId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DeptId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DeptId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Trainees_DeptId",
                table: "Trainees");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CRSId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_CRSResults_CRSId",
                table: "CRSResults");

            migrationBuilder.DropIndex(
                name: "IX_CRSResults_TraineeId",
                table: "CRSResults");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DeptId",
                table: "Courses");
        }
    }
}
