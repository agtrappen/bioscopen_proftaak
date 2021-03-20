using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioscoopsysteem.Migrations
{
    public partial class cast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actor",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Writting",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "releaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "subtitle",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actor",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Writting",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "releaseDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "subtitle",
                table: "Movies");
        }
    }
}
