using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Api.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "AvailableCount", "Model", "Size" },
                values: new object[,]
                {
                    { 1, 10000, "LEGO 8070", "M" },
                    { 2, 10000, "LEGO 8880", "L" },
                    { 3, 10000, "LEGO 42070", "L" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
