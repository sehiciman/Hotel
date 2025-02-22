using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Data.Migrations
{
    /// <inheritdoc />
    public partial class obrisano : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Korisnici_KorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Sobe_Lokacije_lokacijaId",
                table: "Sobe");

            migrationBuilder.DropIndex(
                name: "IX_Sobe_lokacijaId",
                table: "Sobe");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "lokacijaId",
                table: "Sobe");

            migrationBuilder.DropColumn(
                name: "Gosti",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Rezervacije");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lokacijaId",
                table: "Sobe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gosti",
                table: "Rezervacije",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_lokacijaId",
                table: "Sobe",
                column: "lokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Korisnici_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sobe_Lokacije_lokacijaId",
                table: "Sobe",
                column: "lokacijaId",
                principalTable: "Lokacije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
