using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioscoopsysteem.Migrations
{
    public partial class AddTariffToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TariffId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tariffs_TariffId",
                table: "Tickets",
                column: "TariffId",
                principalTable: "Tariffs",
                principalColumn: "TariffId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tariffs_TariffId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TariffId",
                table: "Tickets");
        }
    }
}
