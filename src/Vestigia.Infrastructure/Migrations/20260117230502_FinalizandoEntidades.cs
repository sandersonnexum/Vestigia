using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vestigia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalizandoEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenhaHash",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Transacaos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Transacaos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdLembrete",
                table: "Transacaos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transacaos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Transacaos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataGeracao",
                table: "Relatorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Relatorios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodoFim",
                table: "Relatorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodoInicio",
                table: "Relatorios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Resumo",
                table: "Relatorios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoFinal",
                table: "Relatorios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Relatorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalEntradas",
                table: "Relatorios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSaida",
                table: "Relatorios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Metas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Metas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Metas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdCategoria",
                table: "Metas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdConta",
                table: "Metas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAlvo",
                table: "Metas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAtual",
                table: "Metas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Contas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeConta",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Contas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SaldoInicial",
                table: "Contas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Alertas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Lido",
                table: "Alertas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "Alertas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Alertas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Alertas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InsightIAs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntidadeRelacionada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DataGeracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeloOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsightIAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsightIAs");

            migrationBuilder.DropTable(
                name: "Lembretes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "IdLembrete",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Transacaos");

            migrationBuilder.DropColumn(
                name: "DataGeracao",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "PeriodoFim",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "PeriodoInicio",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "Resumo",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "SaldoFinal",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "TotalEntradas",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "TotalSaida",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "IdConta",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ValorAlvo",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "ValorAtual",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "NomeConta",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "SaldoInicial",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Lido",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Alertas");
        }
    }
}
