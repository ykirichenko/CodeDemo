using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iknowscore.DomainModel.Models
{
    public class MessageMap
    {
        public MessageMap(EntityTypeBuilder<Message> entity)
        {
            entity.ToTable("Message");
            entity.Property(e => e.MessageId).HasColumnName("MessageID").ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDateTimeUtc).ValueGeneratedOnAdd();
        }
    }
}
