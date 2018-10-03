using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class PlayerRoomMap
    {
        public PlayerRoomMap(EntityTypeBuilder<PlayerRoom> entity)
        {
            entity.ToTable("PlayerRoom");
            entity.Property(p => p.PlayerId).HasColumnName("PlayerID");
            entity.Property(p => p.RoomId).HasColumnName("RoomID");
            entity.HasKey(p => new { p.PlayerId, p.RoomId });

            entity.HasOne(pr => pr.Player)
                .WithMany(p => p.PlayerRoom)
                .HasForeignKey(pr => pr.PlayerId)
                .HasConstraintName("FK_PlayerRoom_Player");

            entity.HasOne(pr => pr.Room)
                .WithMany(r => r.PlayerRoom)
                .HasForeignKey(pr => pr.RoomId)
                .HasConstraintName("FK_PlayerRoom_Room");
        }
    }
}
