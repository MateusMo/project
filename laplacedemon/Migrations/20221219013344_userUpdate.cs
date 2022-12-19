using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laplacedemon.Migrations
{
    public partial class userUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Post",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "NVARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User",
                table: "Post",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Post",
                table: "Post",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
