using Microsoft.EntityFrameworkCore;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Enums;

namespace Vestigia.Infrastructure.Data
{
    public class VestigiaContext : DbContext
    {
        public VestigiaContext(DbContextOptions<VestigiaContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<InsightIA> InsightIAs { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties()
                                            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));
                foreach (var property in properties)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey("Id");

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<string>("Nome").IsRequired();
                entity.Property<string>("Email").IsRequired();
                entity.Property<string>("SenhaHash").IsRequired();
                entity.Property<bool>("Ativo").IsRequired();
                entity.Property<DateTime>("DataCriacao").IsRequired();
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Usuario>("Usuario")
                        .WithMany(u => u.Contas)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<string>("NomeConta").IsRequired();
                entity.Property<decimal>("Saldo").IsRequired();
                entity.Property<decimal>("SaldoInicial").IsRequired();
                entity.Property<TipoConta>("Tipo").IsRequired();
                entity.Property<bool>("Ativo").IsRequired();
            });

            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Usuario>("Usuario")
                        .WithMany(u => u.Alertas)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<string>("Mensagem").IsRequired();
                entity.Property<TipoAlerta>("Tipo").IsRequired();
                entity.Property<NivelPrioridade>("Nivel").IsRequired(); 
                entity.Property<DateTime>("DataCriacao").IsRequired();
                entity.Property<bool>("Lido").IsRequired();
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Conta>("Conta")
                        .WithMany(c => c.Transacoes)
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Usuario>("Usuario")
                        .WithMany(u => u.Transacoes)
                        .HasForeignKey("IdUsuario") 
                        .OnDelete(DeleteBehavior.NoAction);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdConta").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<decimal>("Valor").IsRequired();
                entity.Property<string>("Descricao").IsRequired();
                entity.Property<DateTime>("Data").IsRequired();
                entity.Property<StatusTransacao>("Status").IsRequired();
            });

            modelBuilder.Entity<InsightIA>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Usuario>("Usuario")
                        .WithMany(u => u.InsightsIA)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdEntidadeRelacionada").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<TipoInsight>("Tipo").IsRequired();
                entity.Property<DateTime>("DataGeracao").IsRequired();
                entity.Property<string>("ModeloOrigem").IsRequired();
                entity.Property<string>("Conteudo").IsRequired();
            });

            modelBuilder.Entity<Lembrete>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Transacao>("Transacao")
                        .WithMany(t => t.Lembretes)
                        .HasForeignKey("IdTransacao")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdTransacao").IsRequired();
                entity.Property<string>("Titulo").IsRequired();
                entity.Property<string>("Descricao").IsRequired();
                entity.Property<decimal>("Valor").IsRequired();
                entity.Property<DateTime>("DataVencimento").IsRequired();
                entity.Property<bool>("Pago").IsRequired();
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Categoria>("Categoria")
                        .WithMany(c => c.Metas)
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne<Conta>("Conta")
                        .WithMany(c => c.Metas)
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdCategoria").IsRequired();
                entity.Property<Guid>("IdConta").IsRequired();
                entity.Property<string>("Descricao").IsRequired();
                entity.Property<decimal>("ValorAlvo").IsRequired();
                entity.Property<decimal>("ValorAtual").IsRequired();
                entity.Property<DateTime>("DataInicio").IsRequired();
                entity.Property<DateTime>("DataFim").IsRequired();
                entity.Property<StatusMeta>("Status").IsRequired();
            });

            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Usuario>("Usuario")
                        .WithMany(u => u.Relatorios)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<DateTime>("PeriodoInicio").IsRequired();
                entity.Property<DateTime>("PeriodoFim").IsRequired();
                entity.Property<decimal>("TotalEntradas").IsRequired();
                entity.Property<decimal>("TotalSaida").IsRequired();
                entity.Property<decimal>("SaldoFinal").IsRequired();
                entity.Property<DateTime>("DataGeracao").IsRequired();
                entity.Property<TipoRelatorio>("Tipo").IsRequired();
                entity.Property<string>("Resumo").IsRequired();

            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Transacao>("Transacao")
                        .WithMany(u => u.Categorias)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<string>("Nome").IsRequired();
                entity.Property<Guid>("IdUsuario").IsRequired();
                entity.Property<TipoTransacao>("Tipo").IsRequired();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey("Id");
                entity.HasOne<Transacao>("Transacao")
                        .WithMany(t => t.Tags)
                        .HasForeignKey("IdTransacao")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property<Guid>("Id").IsRequired();
                entity.Property<string>("Nome").IsRequired();
                entity.Property<Guid>("IdTransacao").IsRequired();
                entity.Property<string>("CorHex").IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}