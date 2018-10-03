using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class GameMap
    {
        public GameMap(EntityTypeBuilder<Game> entity)
        {
            entity.ToTable("Game");
            entity.Property(g => g.GameId).HasColumnName("GameID").ValueGeneratedOnAdd();
            entity.Property(g => g.Team1Id).HasColumnName("TeamTournament1ID");
            entity.Property(g => g.Team2Id).HasColumnName("TeamTournament2ID");
            entity.Property(g => g.GameDateTime).HasColumnName("Date");

            entity.HasOne(g => g.Tournament)
                .WithMany(t => t.Game)
                .HasForeignKey(g => g.TournamentId)
                .HasConstraintName("FK_Game_Tournament");

            entity.HasOne(g => g.Team1)
                .WithMany(t => t.Games)
                .HasForeignKey(g => g.Team1Id)
                .HasConstraintName("FK_Game_TeamTournament");

            entity.HasOne(g => g.Team2)
                .WithMany()
                .HasForeignKey(g => g.Team2Id)
                .HasConstraintName("FK_Game_TeamTournament1");

        }
    }
}
