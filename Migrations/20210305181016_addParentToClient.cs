using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class addParentToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ParentId",
                table: "Clients",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Persons_ParentId",
                table: "Clients",
                column: "ParentId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Persons_ParentId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ParentId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Clients");
        }
    }
}
