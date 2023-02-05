using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Surasshu.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarriorOneId = table.Column<int>(type: "int", nullable: true),
                    WarriorTwoId = table.Column<int>(type: "int", nullable: true),
                    WarriorThreeId = table.Column<int>(type: "int", nullable: true),
                    WarriorFourId = table.Column<int>(type: "int", nullable: true),
                    WarriorFiveId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnedQuirks",
                columns: table => new
                {
                    OwnedQuirkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuirkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedQuirks", x => x.OwnedQuirkId);
                });

            migrationBuilder.CreateTable(
                name: "Quirks",
                columns: table => new
                {
                    QuirkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuirkName = table.Column<string>(type: "varchar(500)", nullable: false),
                    QuirkDescription = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    QuirkCost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quirks", x => x.QuirkId);
                });

            migrationBuilder.CreateTable(
                name: "Warriors",
                columns: table => new
                {
                    WarriorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarriorName = table.Column<string>(type: "varchar(500)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNinja = table.Column<bool>(type: "bit", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    AttackMod = table.Column<int>(type: "int", nullable: false),
                    DieCount = table.Column<int>(type: "int", nullable: false),
                    DieSide = table.Column<int>(type: "int", nullable: false),
                    Crit = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    QuirkOneId = table.Column<int>(type: "int", nullable: true),
                    QuirkTwoId = table.Column<int>(type: "int", nullable: true),
                    QuirkThreeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warriors", x => x.WarriorId);
                });

            migrationBuilder.CreateTable(
                name: "WarriorTeams",
                columns: table => new
                {
                    WarriorTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WarriorOneId = table.Column<int>(type: "int", nullable: true),
                    WarriorTwoId = table.Column<int>(type: "int", nullable: true),
                    WarriorThreeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarriorTeams", x => x.WarriorTeamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OwnedQuirks");

            migrationBuilder.DropTable(
                name: "Quirks");

            migrationBuilder.DropTable(
                name: "Warriors");

            migrationBuilder.DropTable(
                name: "WarriorTeams");
        }
    }
}
