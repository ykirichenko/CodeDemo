using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class PlayerMap
    {
        public PlayerMap(EntityTypeBuilder<Player> entity)
        {
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID").ValueGeneratedOnAdd();

            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.HasOne(d => d.Country)
                 .WithMany(p => p.Player)
                 .HasForeignKey(d => d.CountryId)
                 .HasConstraintName("FK_Player_Country");
        }
    }
}
