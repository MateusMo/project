using laplacedemon.Models.UserEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

namespace laplacedemon.Data.Mappings.UserMappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("User");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Nickname)
                .IsRequired()
                .HasColumnName("NickName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            // Propriedades
            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.isBloqued)
                .IsRequired()
                .HasColumnName("IsBloqued")
                .HasColumnType("bit");

            builder.HasOne(x => x.UserInfo);
            builder.HasOne(x => x.UserProfile);
            builder.HasOne(x => x.UserProfileView);
        }
    }
}
