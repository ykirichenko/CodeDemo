using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class RoomMap
    {
        public RoomMap(EntityTypeBuilder<Room> entity)
        {
            entity.ToTable("Room");
            entity.Property(e => e.RoomId).HasColumnName("RoomID").ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Private).IsRequired();
        }
    }
}
