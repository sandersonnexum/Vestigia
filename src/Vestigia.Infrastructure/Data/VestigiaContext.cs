using Microsoft.EntityFrameworkCore;
using Vestigia.Domain.Entities;
using Vestigia.Domain.Enums;

namespace Vestigia.Infrastructure.Data
{
    public class VestigiaContext : DbContext
    {
        public VestigiaContext(DbContextOptions<VestigiaContext> options) : base(options) { }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }
        public DbSet<LogSaldo> LogSaldos { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<RelatorioIA> RelatorioIAs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties()
                                            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));
                foreach (var property in properties)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }*/

            modelBuilder.Entity<Transacao>()
                .HasMany(t => t.Tags)
                .WithMany(tag => tag.Transacoes)
                .UsingEntity<Dictionary<string, object>>(
                    "TransacaoTag",
                    j => j.HasOne<Tag>().WithMany().HasForeignKey("IdTag"),
                    j => j.HasOne<Transacao>().WithMany().HasForeignKey("IdTransacao"));

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id).IsRequired();
                entity.Property(u => u.SenhaHash).IsRequired();
                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.Ativo).IsRequired();
                entity.Property(u => u.DataCriacao).IsRequired();

                entity.OwnsOne(u => u.Nome, n =>
                {

                    n.Property(x => x.Valor)
                        .HasColumnName("Nome")
                        .IsRequired();
                });

                entity.OwnsOne(u => u.Email, e =>
                {
                    e.Property(x => x.Valor)
                        .HasColumnName("Email")
                        .IsRequired();
                });

                entity.HasMany(u => u.Contas)
                    .WithOne(c => c.Usuario)
                    .HasForeignKey("IdUsuario")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.Usuario)
                        .WithMany(u => u.Contas)
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);

                entity.Property(c => c.NumeroConta).IsRequired(); 
                entity.Property(c => c.Tipo).IsRequired(); 
                entity.Property(c => c.DataCriacao).IsRequired(); 

                entity.OwnsOne(c => c.NomeConta, n =>
                {
                    n.Property(x => x.Valor)
                        .HasColumnName("NomeConta")
                        .IsRequired();
                });

                entity.OwnsOne(c => c.Saldo, s =>
                {
                    s.Property(x => x.Valor)
                        .HasColumnName("Saldo")
                        .HasPrecision(18, 2)
                        .IsRequired();
                });

                entity.OwnsOne(c => c.SaldoInicial, si =>
                {
                    si.Property(x => x.Valor)
                        .HasColumnName("SaldoInicial")
                        .HasPrecision(18, 2)
                        .IsRequired();
                });
            });

            modelBuilder.Entity<Alerta>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Usuario) 
                    .WithMany(u => u.Alertas)
                    .HasForeignKey(a => a.IdUsuario) 
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(a => a.Mensagem).IsRequired();
                entity.Property(a => a.Tipo).IsRequired(); 
                entity.Property(a => a.Nivel).IsRequired(); 
                entity.Property(a => a.DataCriacao).IsRequired(); 
                
                entity.Property<bool>("Lido").IsRequired(); 
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasOne(t => t.Conta)
                    .WithMany(c => c.Transacoes)
                    .HasForeignKey(t => t.IdConta)
                    .OnDelete(DeleteBehavior.NoAction); 
                
                entity.OwnsOne(t => t.Valor, v =>
                {
                    v.Property(x => x.Valor) 
                        .HasColumnName("Valor")
                        .HasPrecision(18, 2)
                        .IsRequired();
                });

                entity.Property(t => t.Descricao).IsRequired();
                entity.Property(t => t.Data).IsRequired();
                entity.Property(t => t.Tipo).IsRequired();

                entity.HasMany(t => t.Tags)
                    .WithMany(tag => tag.Transacoes)
                    .UsingEntity<Dictionary<string, object>>(
                        "TransacaoTag",
                        j => j.HasOne<Tag>().WithMany().HasForeignKey("IdTag"),
                        j => j.HasOne<Transacao>().WithMany().HasForeignKey("IdTransacao")
                    );
            });

            modelBuilder.Entity<Lembrete>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.HasOne(l => l.Usuario)
                    .WithMany(u => u.Lembretes)
                    .HasForeignKey(l => l.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.OwnsOne(l => l.Nome, n =>
                {
                    n.Property(x => x.Valor)
                        .HasColumnName("Nome")
                        .IsRequired();
                });

                entity.OwnsOne(l => l.Valor, v =>
                {
                    v.Property(x => x.Valor)
                        .HasColumnName("Valor")
                        .HasPrecision(18, 2)
                        .IsRequired();
                });

                entity.Property(l => l.Descricao).IsRequired();
                entity.Property(l => l.DataVencimento).IsRequired();
                entity.Property(l => l.Status).IsRequired();
            });

            modelBuilder.Entity<Meta>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.HasOne(m => m.Usuario)
                    .WithMany(u => u.Metas)
                    .HasForeignKey(m => m.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(m => m.Categoria)
                    .WithMany(c => c.Metas)
                    .HasForeignKey(m => m.IdCategoria)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(m => m.Descricao).IsRequired();
                entity.Property(m => m.DataCriacao).IsRequired();
                entity.Property(m => m.Prazo).IsRequired();
                entity.Property(m => m.Status).IsRequired();

                entity.OwnsOne(m => m.Nome, n =>
                {
                    n.Property(x => x.Valor).HasColumnName("Nome").IsRequired();
                });

                entity.OwnsOne(m => m.ValorAlvo, v =>
                {
                    v.Property(x => x.Valor).HasColumnName("ValorAlvo").HasPrecision(18, 2).IsRequired();
                });

                entity.OwnsOne(m => m.ValorAlcancado, v =>
                {
                    v.Property(x => x.Valor).HasColumnName("ValorAlcancado").HasPrecision(18, 2).IsRequired();
                });
            });

            modelBuilder.Entity<RelatorioIA>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(r => r.Usuario)
                    .WithMany(u => u.Relatorios)
                    .HasForeignKey(r => r.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(r => r.IdEntidadeRelacionada).IsRequired();
                entity.Property(r => r.Data).IsRequired();
                entity.Property(r => r.Tipo).IsRequired();
                entity.Property(r => r.Conteudo).IsRequired();
                entity.Property(r => r.EntidadeRelacionada).IsRequired();
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Usuario)
                    .WithMany(u => u.Categorias) 
                    .HasForeignKey(c => c.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.Property(c => c.Descricao).HasMaxLength(255);

                entity.OwnsOne(c => c.Nome, n =>
                {
                    n.Property(x => x.Valor).HasColumnName("Nome").IsRequired(); 
                });
            });

            modelBuilder.Entity<Tag>(entity =>
            {
               entity.HasKey(t => t.Id); 

                
                entity.HasOne(t => t.Usuario)
                    .WithMany() // Ou u.Tags para navegação inversa
                    .HasForeignKey(t => t.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict); 
                
                entity.OwnsOne(t => t.Nome, n =>
                {
                    n.Property(x => x.Valor).HasColumnName("Nome").IsRequired(); 
                });

            }); 

            modelBuilder.Entity<LogSaldo>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.HasOne(l => l.Conta)
                    .WithMany(c => c.LogSaldos)
                    .HasForeignKey(l => l.IdConta)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey(l => l.IdUsuario)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(l => l.MesReferencia).IsRequired();

                entity.OwnsOne(l => l.SaldoFechamento, v =>
                {
                    v.Property(x => x.Valor)
                        .HasPrecision(18, 2)
                        .IsRequired();
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}