using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class PrimaryLanguageMap
    {
        public PrimaryLanguageMap(EntityTypeBuilder<PrimaryLanguage> entity)
        {
            entity.ToTable("PrimaryLanguage");
            entity.Property(e => e.PrimaryLanguageId).HasColumnName("PrimaryLanguageId").ValueGeneratedOnAdd();
            entity.Property(e => e.Locale).HasColumnName("Locale").IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
        }
    }
}
