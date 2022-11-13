using laplacedemon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

namespace laplacedemon.Data.Mappings
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

            builder.Property(x => x.Coin)
                .IsRequired()
                .HasColumnName("Coin")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);


            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("DateTimeOffset");

            builder.Property(x => x.isActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("int");

            builder.Property(x => x.likes)
                .IsRequired()
                .HasColumnName("Likes")
                .HasColumnType("int");


            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Post)
                .HasConstraintName("FK_Post_User")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
