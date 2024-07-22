using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GC.Infrastructure.Persistence.Configuration
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.HasKey(x => x.Id);

            // Configurar o relacionamento com Paciente
            builder.HasOne(c => c.NomePaciente)
                   .WithMany() 
                   .HasForeignKey(c => c.IdPaciente)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configurar o relacionamento com o Medico 
            builder.HasOne(m => m.NomeMedico)
                .WithMany()
                .HasForeignKey(m => m.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar o relacionamento com o Servico 
            builder.HasOne(s =>s.NomeServico)
                .WithMany()
                .HasForeignKey(s => s.IdServico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
