using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitacaoProposta.Migrations
{
    /// <inheritdoc />
    public partial class AjustaAgente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "varchar(20)",
                table: "Agentes",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Agentes",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Agentes",
                newName: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "varchar(20)",
                table: "Agentes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}
