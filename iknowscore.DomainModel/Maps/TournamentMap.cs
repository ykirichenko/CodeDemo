using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class TournamentMap
    {
        public TournamentMap(EntityTypeBuilder<Tournament> entity)
        {
            entity.ToTable("Tournament");
            entity.Property(t => t.TournamentId).HasColumnName("TournamentID").ValueGeneratedOnAdd();
        }
    }
}
