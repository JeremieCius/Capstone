using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surasshu.Migrations
{
    public partial class WarriorImagePatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Warriors",
                type: "varchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Warriors");
        }
    }
}
