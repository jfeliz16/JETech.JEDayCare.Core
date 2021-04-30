using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class removeContryPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Contries_ContryId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ContryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ContryId",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContryId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ContryId",
                table: "Persons",
                column: "ContryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Contries_ContryId",
                table: "Persons",
                column: "ContryId",
                principalTable: "Contries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
