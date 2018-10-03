using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class TeamMap
    {
        public TeamMap(EntityTypeBuilder<Team> entity)
        {
            entity.ToTable("Team");
            entity.Property(e => e.TeamId).HasColumnName("TeamID").ValueGeneratedOnAdd();
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

            entity.HasOne(d => d.Country)
                .WithMany(p => p.Team)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Team_Country");
        }
    }
}
