using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportTimetable.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addroutestopuniqueindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RouteStop_RouteId_StopId",
                table: "RouteStop",
                columns: new[] { "RouteId", "StopId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RouteStop_RouteId_StopId",
                table: "RouteStop");
        }
    }
}
