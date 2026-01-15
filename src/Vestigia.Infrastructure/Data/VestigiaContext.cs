using Microsoft.EntityFrameworkCore;
using Vestigia.Domain.Entities;

namespace Vestigia.Infrastructure.Data
{
    public class VestigiaContext : DbContext
    {
        public VestigiaContext(DbContextOptions<VestigiaContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        //public DbSet<InsightIA> InsightIAs { get; set; }
        //public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }

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
                entity.Property<Guid>("Id").IsRequired();
            });

            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });

            /*modelBuilder.Entity<InsightIA>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });

            modelBuilder.Entity<Lembrete>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });*/

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });

            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasKey("Id");
                entity.Property<Guid>("Id").IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}