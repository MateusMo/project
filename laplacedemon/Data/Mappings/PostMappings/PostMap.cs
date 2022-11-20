using laplacedemon.Models.PostEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

namespace laplacedemon.Data.Mappings.PostMappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasColumnName("Comment")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000);

            builder.Property(x => x.SuggestedPrice)
                .IsRequired()
                .HasColumnName("SuggestedPrice")
                .HasColumnType("FLOAT");

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("DateTimeOffset");

            builder.Property(x => x.isActive)
                .IsRequired()
                .HasColumnName("isActive")
                .HasColumnType("Bit");

            builder.Property(x => x.Bulls)
                .IsRequired()
                .HasColumnName("Bulls")
                .HasColumnType("int");

            builder.Property(x => x.Bears)
                .IsRequired()
                .HasColumnName("Bears")
                .HasColumnType("int");

            //relacionamentos
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Post)
                .HasConstraintName("FK_Post_User")
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.Coin)
               .WithMany(x => x.Post)
               .HasConstraintName("FK_Post_Coin")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
