using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GC.Infrastructure.Persistence.Configuration
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder.HasMany(x => x.Atendimentos)
                .WithOne(x => x.NomeMedico)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .OwnsOne(d => d.Endereco, e =>
                {
                    e.Property(e => e.Bairro).HasColumnName("Bairro");
                    e.Property(e => e.Cidade).HasColumnName("Cidade");
                    e.Property(e => e.Logradouro).HasColumnName("Logradouro");
                    e.Property(e => e.Uf).HasColumnName("UF");
                    e.Property(e => e.Cep).HasColumnName("CEP");
                    e.Property(e => e.Numero).HasColumnName("Numero");
                    e.Property(e => e.Referencia).HasColumnName("Referencia");
                });

        }
    }
}
