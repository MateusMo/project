using laplacedemon.Models.UserEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laplacedemon.Data.Mappings.UserMappings
{
    public class UserInfoMap : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            // Tabela
            builder.ToTable("UserInfo");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Photo)
                .IsRequired()
                .HasColumnName("Photo")
                .HasColumnType("varchar");

            builder.Property(x => x.TrustedAsAnalist)
                .IsRequired()
                .HasColumnName("TrustedAsAnalist")
                .HasColumnType("int");

            builder.Property(x => x.TrustedAsExpertAnalist)
                .IsRequired()
                .HasColumnName("TrustedAsExpertAnalist")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);
        }
    }
}
