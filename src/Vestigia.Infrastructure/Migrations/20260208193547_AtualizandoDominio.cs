using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vestigia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoDominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Transacaos_IdUsuario",
                table: "Categorias");

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
                name: "FK_Tags_Transacaos_IdTransacao",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacaos_Usuarios_IdUsuario",
                table: "Transacaos");

            migrationBuilder.DropTable(
                name: "InsightIAs");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Transacaos_IdUsuario",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "CorHex",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ValorAtual",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Lembretes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Transacaos",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Transacaos",
                newName: "IdCategoria");

            migrationBuilder.RenameColumn(
                name: "IdTransacao",
                table: "Tags",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_IdTransacao",
                table: "Tags",
                newName: "IX_Tags_IdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdConta",
                table: "Metas",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Metas",
                newName: "Prazo");

            migrationBuilder.RenameColumn(
                name: "DataFim",
                table: "Metas",
                newName: "DataCriacao");

            migrationBuilder.RenameIndex(
                name: "IX_Metas_IdConta",
                table: "Metas",
                newName: "IX_Metas_IdUsuario");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Lembretes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "IdTransacao",
                table: "Lembretes",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Lembretes_IdTransacao",
                table: "Lembretes",
                newName: "IX_Lembretes_IdUsuario");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdTags",
                table: "Transacaos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Metas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAlcancado",
                table: "Metas",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Lembretes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Contas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NumeroConta",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategoriaTransacao",
                columns: table => new
                {
                    CategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaTransacao", x => new { x.CategoriasId, x.TransacoesId });
                    table.ForeignKey(
                        name: "FK_CategoriaTransacao_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaTransacao_Transacaos_TransacoesId",
                        column: x => x.TransacoesId,
                        principalTable: "Transacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogSaldos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdConta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MesReferencia = table.Column<DateOnly>(type: "date", nullable: false),
                    SaldoFechamento_Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogSaldos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogSaldos_Contas_IdConta",
                        column: x => x.IdConta,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogSaldos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatorioIAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntidadeRelacionada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadeRelacionada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioIAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatorioIAs_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransacaoTag",
                columns: table => new
                {
                    IdTag = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTransacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacaoTag", x => new { x.IdTag, x.IdTransacao });
                    table.ForeignKey(
                        name: "FK_TransacaoTag_Tags_IdTag",
                        column: x => x.IdTag,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransacaoTag_Transacaos_IdTransacao",
                        column: x => x.IdTransacao,
                        principalTable: "Transacaos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaTransacao_TransacoesId",
                table: "CategoriaTransacao",
                column: "TransacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_LogSaldos_IdConta",
                table: "LogSaldos",
                column: "IdConta");

            migrationBuilder.CreateIndex(
                name: "IX_LogSaldos_IdUsuario",
                table: "LogSaldos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioIAs_IdUsuario",
                table: "RelatorioIAs",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TransacaoTag_IdTransacao",
                table: "TransacaoTag",
                column: "IdTransacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_IdUsuario",
                table: "Categorias",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lembretes_Usuarios_IdUsuario",
                table: "Lembretes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Categorias_IdCategoria",
                table: "Metas",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metas_Usuarios_IdUsuario",
                table: "Metas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Usuarios_IdUsuario",
                table: "Tags",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_IdUsuario",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Lembretes_Usuarios_IdUsuario",
                table: "Lembretes");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Categorias_IdCategoria",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metas_Usuarios_IdUsuario",
                table: "Metas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Usuarios_IdUsuario",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "CategoriaTransacao");

            migrationBuilder.DropTable(
                name: "LogSaldos");

            migrationBuilder.DropTable(
                name: "RelatorioIAs");

            migrationBuilder.DropTable(
                name: "TransacaoTag");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdTags",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ValorAlcancado",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Lembretes");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "NumeroConta",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Categorias");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Transacaos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Transacaos",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Tags",
                newName: "IdTransacao");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_IdUsuario",
                table: "Tags",
                newName: "IX_Tags_IdTransacao");

            migrationBuilder.RenameColumn(
                name: "Prazo",
                table: "Metas",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Metas",
                newName: "IdConta");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Metas",
                newName: "DataFim");

            migrationBuilder.RenameIndex(
                name: "IX_Metas_IdUsuario",
                table: "Metas",
                newName: "IX_Metas_IdConta");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Lembretes",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Lembretes",
                newName: "IdTransacao");

            migrationBuilder.RenameIndex(
                name: "IX_Lembretes_IdUsuario",
                table: "Lembretes",
                newName: "IX_Lembretes_IdTransacao");

            migrationBuilder.AddColumn<string>(
                name: "CorHex",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAtual",
                table: "Metas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Lembretes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Contas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InsightIAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEntidadeRelacionada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModeloOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsightIAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsightIAs_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodoInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    TotalEntradas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSaida = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatorios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacaos_IdUsuario",
                table: "Transacaos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_InsightIAs_IdUsuario",
                table: "InsightIAs",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_IdUsuario",
                table: "Relatorios",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Transacaos_IdUsuario",
                table: "Categorias",
                column: "IdUsuario",
                principalTable: "Transacaos",
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
                name: "FK_Tags_Transacaos_IdTransacao",
                table: "Tags",
                column: "IdTransacao",
                principalTable: "Transacaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacaos_Usuarios_IdUsuario",
                table: "Transacaos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
