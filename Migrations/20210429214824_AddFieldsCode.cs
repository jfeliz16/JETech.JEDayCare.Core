using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class AddFieldsCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbrv",
                table: "Contries");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "States",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Contries",
                maxLength: 3,
                nullable: false,
                defaultValueSql: "'--'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "States");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Contries");

            migrationBuilder.AddColumn<string>(
                name: "Abbrv",
                table: "Contries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValueSql: "'--'");
        }
    }
}
