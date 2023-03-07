using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surasshu.Migrations
{
    public partial class OwnedQuirkPatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OwnedQuirks");

            migrationBuilder.AddColumn<bool>(
                name: "IsEquipped",
                table: "OwnedQuirks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WarriorId",
                table: "OwnedQuirks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEquipped",
                table: "OwnedQuirks");

            migrationBuilder.DropColumn(
                name: "WarriorId",
                table: "OwnedQuirks");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OwnedQuirks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
