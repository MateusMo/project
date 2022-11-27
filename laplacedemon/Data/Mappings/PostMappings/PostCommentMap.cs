using Microsoft.EntityFrameworkCore;
using laplacedemon.Models.PostEnvironment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laplacedemon.Data.Mappings.PostMappings
{
    public class PostCommentMap : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasColumnName("Text")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000);

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("DateTimeOffset");

            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.PostComments)
                .HasConstraintName("FK_PostComment_Post")
                ;

            builder.HasOne(x => x.User);
        }
    }
}
