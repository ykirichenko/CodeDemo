using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class ForecastMap
    {
        public ForecastMap(EntityTypeBuilder<Forecast> entity)
        {
            entity.ToTable("Forecast");
            entity.Property(f => f.ForecastId).HasColumnName("ForecastID").ValueGeneratedOnAdd();
            entity.Property(f => f.GameId).HasColumnName("GameID");
            entity.Property(f => f.PlayerId).HasColumnName("PlayerID");

            entity.HasOne(f => f.Player)
                .WithMany(p => p.Forecasts)
                .HasForeignKey(f => f.Player)
                .HasConstraintName("FK_Forecast_Player");

            entity.HasOne(f => f.Game)
                .WithMany(g => g.Forecasts)
                .HasForeignKey(f => f.GameId)
                .HasConstraintName("FK_Forecast_Game");
        }
    }
}
