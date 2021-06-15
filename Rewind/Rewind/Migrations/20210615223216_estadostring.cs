using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rewind.Migrations
{
    public partial class estadostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado",
                table: "Comentarios",
                newName: "Estado");

            migrationBuilder.AlterColumn<string>(
                name: "Utilizador",
                table: "Utilizadores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilizadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "ID", "Estudio", "Pais" },
                values: new object[,]
                {
                    { 1, "ABC", "Portugal" },
                    { 2, "ACR", "França" },
                    { 3, "TCB", "Espanha" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "ID", "Email", "UserName", "Utilizador" },
                values: new object[,]
                {
                    { 1, "a@aa", null, "admin" },
                    { 2, "b@bb", null, "antonio" },
                    { 3, "c@cc", null, "tomas" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "ID", "Ano", "Data", "Episodios", "Estado", "EstudioID", "Imagem", "Sinopse", "Titulo" },
                values: new object[] { 1, 2004, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "continuando", 1, "a.jpg", "Morbi laoreet neque", "Lorem ipsum" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "ID", "Ano", "Data", "Episodios", "Estado", "EstudioID", "Imagem", "Sinopse", "Titulo" },
                values: new object[] { 2, 2005, new DateTime(2021, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "terminado", 2, "b.jpg", "ut erat gravida", "dolor sit amet" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "ID", "Ano", "Data", "Episodios", "Estado", "EstudioID", "Imagem", "Sinopse", "Titulo" },
                values: new object[] { 3, 2012, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "continuando", 3, "c.jpg", "Integer mattis lorem et lorem", "consectetur adipiscing elit" });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "ID", "Comentario", "Data", "Estado", "Estrelas", "SeriesID", "UtilizadoresID" },
                values: new object[] { 1, "bom", new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "visivel", 0, 1, 1 });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "ID", "Comentario", "Data", "Estado", "Estrelas", "SeriesID", "UtilizadoresID" },
                values: new object[] { 2, "mau", new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "invisivel", 0, 2, 2 });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "ID", "Comentario", "Data", "Estado", "Estrelas", "SeriesID", "UtilizadoresID" },
                values: new object[] { 3, "mais ou menos", new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "visivel", 0, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comentarios",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estudios",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudios",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudios",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Comentarios",
                newName: "estado");

            migrationBuilder.AlterColumn<string>(
                name: "Utilizador",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "estado",
                table: "Comentarios",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
