using Microsoft.EntityFrameworkCore.Migrations;

namespace Rewind.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "Estrelas",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 2,
                column: "Estrelas",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 3,
                column: "Estrelas",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "Estrelas",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 2,
                column: "Estrelas",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 3,
                column: "Estrelas",
                value: 0);
        }
    }
}
