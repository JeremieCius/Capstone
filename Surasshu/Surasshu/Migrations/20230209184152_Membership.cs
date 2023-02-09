using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surasshu.Migrations
{
    public partial class Membership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlatinumMember",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlatinumMember",
                table: "AspNetUsers");
        }
    }
}
