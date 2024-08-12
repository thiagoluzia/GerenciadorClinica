using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GC.Infrastructure.Persistence.Configuration
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(s => s.Atendimentos)
                  .WithOne(a => a.Servico)
                  .HasForeignKey(a => a.IdServico)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}
