using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class TeamTournamentMap
    {
        public TeamTournamentMap(EntityTypeBuilder<TeamTournament> entity)
        {
            entity.ToTable("TeamTournament");
            entity.Property(t => t.TeamTournamentId).HasColumnName("TeamTournamentID").ValueGeneratedOnAdd();
            //entity.HasAlternateKey(t => new { t.TeamId, t.TournamentId });

            entity.HasOne(tt => tt.Tournament)
                .WithMany(t => t.TeamTournament)
                .HasForeignKey(tt => tt.TournamentId)
                .HasConstraintName("FK_TeamTournament_Tournament");

            entity.HasOne(tt => tt.Team)
                .WithMany(t => t.TeamTournament)
                .HasForeignKey(tt => tt.TeamId)
                .HasConstraintName("FK_TeamTournament_Team");
        }
    }
}
