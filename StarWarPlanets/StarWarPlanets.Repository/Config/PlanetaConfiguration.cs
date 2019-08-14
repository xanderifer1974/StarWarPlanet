using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarPlanets.Domain.Entidades;

namespace StarWarPlanets.Repository.Config
{
    public class PlanetaConfiguration : IEntityTypeConfiguration<Planeta>
    {
        public void Configure(EntityTypeBuilder<Planeta> builder)
        {
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(30);
            builder
                .Property(p => p.Clima)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Terreno)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(p => p.QtdAparicao)
                .IsRequired();
        }
    }
}
