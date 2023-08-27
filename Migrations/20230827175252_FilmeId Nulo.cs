using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApiRest.Migrations
{
    /// <inheritdoc />
    public partial class FilmeIdNulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "sessoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes");

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "sessoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_filmes_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
