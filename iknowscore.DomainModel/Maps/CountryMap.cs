using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class CountryMap
    {
        public CountryMap(EntityTypeBuilder<Country> entity)
        {
            entity.ToTable("Country"); 
            entity.Property(e => e.CountryId).HasColumnName("CountryID").ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
