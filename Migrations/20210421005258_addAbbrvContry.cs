using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JETech.JEDayCare.Core.Migrations
{
    public partial class addAbbrvContry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InitDate",
                table: "Persons",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Abbrv",
                table: "Contries",
                maxLength: 3,
                nullable: false,
                defaultValueSql: "--");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbrv",
                table: "Contries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InitDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
