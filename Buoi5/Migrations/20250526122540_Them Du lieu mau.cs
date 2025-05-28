using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi5.Migrations
{
    /// <inheritdoc />
    public partial class ThemDulieumau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm dữ liệu vào bảng Grades
            migrationBuilder.InsertData(
                table: "Grades",
                columns: [ "GradeId", "GradeName" ],
                values: [ 1, "21DTHA1" ]
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: ["GradeId", "GradeName"],
                values: [2, "21DTHA2"]
            );

            migrationBuilder.InsertData(
                table: "Grades",
                columns: ["GradeId", "GradeName"],
                values: [3, "21DTHA3"]
            );

            // Thêm dữ liệu vào bảng Students
            migrationBuilder.InsertData(
                table: "Students",
                columns: ["StudentId", "FirstName", "LastName", "GradeId" ],
                values: [ 1, "Khuyên", "Bùi", 1 ]
            );

            migrationBuilder.InsertData(
                table: "Students",
                columns: ["StudentId", "FirstName", "LastName", "GradeId"],
                values: [2, "Toàn", "Nguyễn", 1]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
