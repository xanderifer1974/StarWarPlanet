using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarPlanets.Domain.Entidades;

namespace StarWarPlanets.Repository.Config
{
    public class PlanetaConfiguration : IEntityTypeConfiguration<Planeta>
    {
        public void Configure(EntityTypeBuilder<Planeta> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
