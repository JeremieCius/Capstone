using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surasshu.Migrations
{
    public partial class BotMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBotAccount",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorEightId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorEighteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorElevenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorFifteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorFourteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorNineId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorNineteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorSevenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorSeventeenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorSixId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorSixteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorTenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorThirteenId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorTwelveId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorTwentyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarriorTwentyOneId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBotAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorEightId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorEighteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorElevenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorFifteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorFourteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorNineId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorNineteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorSevenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorSeventeenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorSixId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorSixteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorTenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorThirteenId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorTwelveId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorTwentyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WarriorTwentyOneId",
                table: "AspNetUsers");
        }
    }
}
