using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class TemplateMap
    {
        public TemplateMap(EntityTypeBuilder<Template> entity)
        {
            entity.ToTable("Template");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID").ValueGeneratedOnAdd();
            entity.Property(e => e.PrimaryLanguageId).HasColumnName("PrimaryLanguageId");
            entity.Property(e => e.TemplateTypeId).HasColumnName("TemplateTypeId");
            entity.Property(e => e.TournamentId).HasColumnName("TournamentId");
            entity.Property(e => e.Title).HasColumnName("Title").IsRequired().HasMaxLength(50);
            entity.Property(e => e.Content).HasColumnName("Content").IsRequired();

            entity.HasOne(d => d.PrimaryLanguage)
                .WithMany(p => p.Templates)
                .HasForeignKey(d => d.PrimaryLanguageId)
                .HasConstraintName("FK_Template_PrimaryLanguage");

            entity.HasOne(d => d.Tournament)
                .WithMany(p => p.Templates)
                .HasForeignKey(d => d.PrimaryLanguageId)
                .HasConstraintName("FK_Template_Tournament");
        }
    }
}
