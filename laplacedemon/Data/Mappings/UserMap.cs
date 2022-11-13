using laplacedemon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

namespace laplacedemon.Data.Mappings
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

            builder.Property(x => x.isBloqued)
                .IsRequired()
                .HasColumnName("IsBloqued")
                .HasColumnType("int");

            builder.Property(x => x.base64Photo)
                .IsRequired()
                .HasColumnName("Base64Photo")
                .HasColumnType("NVARCHAR");

            
        }
    }
}
