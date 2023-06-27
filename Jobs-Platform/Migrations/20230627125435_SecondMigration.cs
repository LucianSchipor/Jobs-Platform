using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accountd_ID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "experience",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "industry",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "location",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "requirements",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "Appliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Accountd_ID = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    industry = table.Column<int>(type: "int", nullable: false),
                    requirements = table.Column<int>(type: "int", nullable: false),
                    experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appliers_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appliers");

            migrationBuilder.AddColumn<int>(
                name: "Accountd_ID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "experience",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "industry",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "requirements",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "salary",
                table: "Accounts",
                type: "int",
                nullable: true);
        }
    }
}
