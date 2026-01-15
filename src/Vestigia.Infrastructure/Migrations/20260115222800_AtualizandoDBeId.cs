using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vestigia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoDBeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio");

            migrationBuilder.RenameTable(
                name: "Transacao",
                newName: "Transacaos");

            migrationBuilder.RenameTable(
                name: "Relatorio",
                newName: "Relatorios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacaos",
                table: "Transacaos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorios",
                table: "Relatorios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacaos",
                table: "Transacaos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relatorios",
                table: "Relatorios");

            migrationBuilder.RenameTable(
                name: "Transacaos",
                newName: "Transacao");

            migrationBuilder.RenameTable(
                name: "Relatorios",
                newName: "Relatorio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacao",
                table: "Transacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relatorio",
                table: "Relatorio",
                column: "Id");
        }
    }
}
