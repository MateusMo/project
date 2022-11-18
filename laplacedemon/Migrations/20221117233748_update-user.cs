using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace laplacedemon.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Analist",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsExpert",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analist",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsExpert",
                table: "User");
        }
    }
}
