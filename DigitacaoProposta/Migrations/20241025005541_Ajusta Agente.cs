using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class AjustaAgente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CpfAgente",
                table: "Agentes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfAgente",
                table: "Agentes");
        }
    }
}
