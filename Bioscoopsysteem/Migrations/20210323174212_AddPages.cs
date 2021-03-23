using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioscoopsysteem.Migrations
{
    public partial class AddPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "ArrangementId",
            //    table: "Tickets",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "TariffId",
            //    table: "Tickets",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageId);
                });

            //migrationBuilder.CreateTable(
            //    name: "Tariffs",
            //    columns: table => new
            //    {
            //        TariffId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tariffs", x => x.TariffId);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tickets_ArrangementId",
            //    table: "Tickets",
            //    column: "ArrangementId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tickets_SeatId",
            //    table: "Tickets",
            //    column: "SeatId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tickets_ShowId",
            //    table: "Tickets",
            //    column: "ShowId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Tickets_TariffId",
            //    table: "Tickets",
            //    column: "TariffId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tickets_Arrangements_ArrangementId",
            //    table: "Tickets",
            //    column: "ArrangementId",
            //    principalTable: "Arrangements",
            //    principalColumn: "ArrangementId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tickets_Seats_SeatId",
            //    table: "Tickets",
            //    column: "SeatId",
            //    principalTable: "Seats",
            //    principalColumn: "SeatId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tickets_Shows_ShowId",
            //    table: "Tickets",
            //    column: "ShowId",
            //    principalTable: "Shows",
            //    principalColumn: "ShowId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Tickets_Tariffs_TariffId",
            //    table: "Tickets",
            //    column: "TariffId",
            //    principalTable: "Tariffs",
            //    principalColumn: "TariffId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Tickets_Arrangements_ArrangementId",
            //    table: "Tickets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Tickets_Seats_SeatId",
            //    table: "Tickets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Tickets_Shows_ShowId",
            //    table: "Tickets");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Tickets_Tariffs_TariffId",
            //    table: "Tickets");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Tariffs");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tickets_ArrangementId",
            //    table: "Tickets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tickets_SeatId",
            //    table: "Tickets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tickets_ShowId",
            //    table: "Tickets");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tickets_TariffId",
            //    table: "Tickets");

            //migrationBuilder.DropColumn(
            //    name: "ArrangementId",
            //    table: "Tickets");

            //migrationBuilder.DropColumn(
            //    name: "TariffId",
            //    table: "Tickets");
        }
    }
}
