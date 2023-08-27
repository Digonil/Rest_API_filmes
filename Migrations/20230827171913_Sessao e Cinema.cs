using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApiRest.Migrations
{
    /// <inheritdoc />
    public partial class SessaoeCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "sessoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes",
                column: "CinemaId",
                principalTable: "cinemas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_cinemas_CinemaId",
                table: "sessoes");

            migrationBuilder.DropIndex(
                name: "IX_sessoes_CinemaId",
                table: "sessoes");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "sessoes");
        }
    }
}
