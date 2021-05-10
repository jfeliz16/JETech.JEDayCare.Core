using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class AddAttendances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAttendance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendaceId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    AttendaceValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceDetails_Attendances_AttendaceId",
                        column: x => x.AttendaceId,
                        principalTable: "Attendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetails_AttendaceId",
                table: "AttendanceDetails",
                column: "AttendaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetails_ClientId",
                table: "AttendanceDetails",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceDetails");

            migrationBuilder.DropTable(
                name: "Attendances");
        }
    }
}
