using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vestigia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelacionamentosEDecimais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLembrete",
                table: "Transacaos",
                newName: "IdUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "Transacaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdTransacao",
                table: "Lembretes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "InsightIAs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Contas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Alertas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Transacaos_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Transacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorHex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTransacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Transacaos_IdTransacao",
                        column: x => x.IdTransacao,
                        principalTable: "Transacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdConta",
                table: "Transacaos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdUsuario",
                table: "Transacaos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_IdUsuario",
                table: "Relatorios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_IdCategoria",
                table: "Metas",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_IdConta",
                table: "Metas",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_IdTransacao",
                table: "Lembretes",
                column: "IdTransacao");

            migrationBuilder.CreateIndex(
                name: "IX_InsightIAs_IdUsuario",
                table: "InsightIAs",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_IdUsuario",
                table: "Contas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdUsuario",
                table: "Alertas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdUsuario",
                table: "Categorias",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IdTransacao",
                table: "Tags",
                column: "IdTransacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Usuarios_IdUsuario",
                table: "Alertas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Usuarios_IdUsuario",
                table: "Contas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsightIAs_Usuarios_IdUsuario",
                table: "InsightIAs",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lembretes_Transacaos_IdTransacao",
                table: "Lembretes",
                column: "IdTransacao",
                principalTable: "Transacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Categorias_IdCategoria",
                table: "Metas",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Contas_IdConta",
                table: "Metas",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorios_Usuarios_IdUsuario",
                table: "Relatorios",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos",
                column: "IdConta",
                principalTable: "Contas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Usuarios_IdUsuario",
                table: "Transacaos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Usuarios_IdUsuario",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Usuarios_IdUsuario",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_InsightIAs_Usuarios_IdUsuario",
                table: "InsightIAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lembretes_Transacaos_IdTransacao",
                table: "Lembretes");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Categorias_IdCategoria",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Contas_IdConta",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatorios_Usuarios_IdUsuario",
                table: "Relatorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Contas_IdConta",
                table: "Transacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Usuarios_IdUsuario",
                table: "Transacaos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_IdConta",
                table: "Transacaos");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_IdUsuario",
                table: "Transacaos");

            migrationBuilder.DropIndex(
                name: "IX_Relatorios_IdUsuario",
                table: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Metas_IdCategoria",
                table: "Metas");

            migrationBuilder.DropIndex(
                name: "IX_Metas_IdConta",
                table: "Metas");

            migrationBuilder.DropIndex(
                name: "IX_Lembretes_IdTransacao",
                table: "Lembretes");

            migrationBuilder.DropIndex(
                name: "IX_InsightIAs_IdUsuario",
                table: "InsightIAs");

            migrationBuilder.DropIndex(
                name: "IX_Contas_IdUsuario",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_IdUsuario",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "IdTransacao",
                table: "Lembretes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "InsightIAs");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Alertas");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Transacaos",
                newName: "IdLembrete");
        }
    }
}
