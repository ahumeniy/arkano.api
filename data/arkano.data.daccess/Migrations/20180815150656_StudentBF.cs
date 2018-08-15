using Microsoft.EntityFrameworkCore.Migrations;

namespace arkano.data.daccess.Migrations
{
    public partial class StudentBF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestFriendId",
                table: "Student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_BestFriendId",
                table: "Student",
                column: "BestFriendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student_BestFriendId",
                table: "Student",
                column: "BestFriendId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student_BestFriendId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_BestFriendId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "BestFriendId",
                table: "Student");
        }
    }
}
