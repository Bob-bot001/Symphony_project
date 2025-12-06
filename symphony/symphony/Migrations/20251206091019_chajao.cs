using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace symphony.Migrations
{
    /// <inheritdoc />
    public partial class chajao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "teacehr_gmail",
                table: "tbl_teacher",
                newName: "teacher_gmail");

            migrationBuilder.RenameColumn(
                name: "teacehr_Name",
                table: "tbl_teacher",
                newName: "teacher_Name");

            migrationBuilder.CreateTable(
                name: "coursetopic",
                columns: table => new
                {
                    ct_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ct_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursetopic", x => x.ct_id);
                    table.ForeignKey(
                        name: "FK_coursetopic_tbl_course_course_id",
                        column: x => x.course_id,
                        principalTable: "tbl_course",
                        principalColumn: "course_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coursetopic_course_id",
                table: "coursetopic",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursetopic");

            migrationBuilder.RenameColumn(
                name: "teacher_gmail",
                table: "tbl_teacher",
                newName: "teacehr_gmail");

            migrationBuilder.RenameColumn(
                name: "teacher_Name",
                table: "tbl_teacher",
                newName: "teacehr_Name");
        }
    }
}
