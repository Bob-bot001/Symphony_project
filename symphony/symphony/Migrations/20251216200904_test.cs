using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "student_age",
                table: "tbl_student");

            migrationBuilder.RenameColumn(
                name: "student_password",
                table: "tbl_student",
                newName: "student_address");

            migrationBuilder.AddColumn<int>(
                name: "student_phone",
                table: "tbl_student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "student_phone",
                table: "tbl_student");

            migrationBuilder.RenameColumn(
                name: "student_address",
                table: "tbl_student",
                newName: "student_password");

            migrationBuilder.AddColumn<int>(
                name: "student_age",
                table: "tbl_student",
                type: "int",
                nullable: true);
        }
    }
}
