using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Data.Migrations
{
    /// <inheritdoc />
    public partial class vraceno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lokacijaId",
                table: "Sobe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sobe_lokacijaId",
                table: "Sobe",
                column: "lokacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sobe_Lokacije_lokacijaId",
                table: "Sobe",
                column: "lokacijaId",
                principalTable: "Lokacije",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sobe_Lokacije_lokacijaId",
                table: "Sobe");

            migrationBuilder.DropIndex(
                name: "IX_Sobe_lokacijaId",
                table: "Sobe");

            migrationBuilder.DropColumn(
                name: "lokacijaId",
                table: "Sobe");
        }
    }
}
