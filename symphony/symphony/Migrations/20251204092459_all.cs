using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_course",
                columns: table => new
                {
                    course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_course", x => x.course_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    student_age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_student", x => x.student_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_teacher",
                columns: table => new
                {
                    teacehr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacehr_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacehr_gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacher_phone = table.Column<int>(type: "int", nullable: true),
                    teacher_age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_teacher", x => x.teacehr_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_course");

            migrationBuilder.DropTable(
                name: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_teacher");
        }
    }
}
