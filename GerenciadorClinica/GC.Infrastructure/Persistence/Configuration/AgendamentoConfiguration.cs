using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GC.Infrastructure.Persistence.Configuration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);

            // Configurar o relacionamento com Paciente
            builder.HasOne(a => a.Paciente)
                   .WithMany(p =>p.Agendamentos) 
                   .HasForeignKey(a => a.IdPaciente)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            // Configurar o relacionamento com o Medico 
            builder.HasOne(a => a.Medico)
                .WithMany(m => m.Agendamentos)
                .HasForeignKey(a=> a.IdMedico)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar o relacionamento com o Servico 
            builder.HasOne(a =>a.Servico)
                .WithMany(s => s.Atendimentos)
                .HasForeignKey(a => a.IdServico)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
