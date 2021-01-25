using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class AddState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Contries_ContryId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContryId",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Cities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ContryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Contries_ContryId",
                        column: x => x.ContryId,
                        principalTable: "Contries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_StateId",
                table: "Persons",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_ContryId",
                table: "States",
                column: "ContryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Contries_ContryId",
                table: "Cities",
                column: "ContryId",
                principalTable: "Contries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_States_StateId",
                table: "Persons",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Contries_ContryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_States_StateId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_Persons_StateId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "ContryId",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Contries_ContryId",
                table: "Cities",
                column: "ContryId",
                principalTable: "Contries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
