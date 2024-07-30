using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GC.Infrastructure.Persistence.Configuration
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.HasMany(x => x.Atendimentos)
                          .WithOne()
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
