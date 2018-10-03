using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class FeedbackMap
    {
        public FeedbackMap(EntityTypeBuilder<Feedback> entity)
        {
            entity.ToTable("Feedback");
            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID").ValueGeneratedOnAdd();
            entity.Property(e => e.PlayerId).HasColumnName("PlayerID");
            entity.Property(e => e.MessageTo).HasColumnName("MessageTo").IsRequired().HasMaxLength(50);
            entity.Property(e => e.Subject).HasColumnName("Subject").HasMaxLength(50);
            entity.Property(e => e.Message).HasColumnName("Message").IsRequired();
            entity.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();

            entity.HasOne(d => d.Player)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_Feedback_Player");
        }
    }
}
