using laplacedemon.Models.CoinEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laplacedemon.Data.Mappings.CoinMappings
{
    public class CoinMap : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("CoinObj");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(800);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("Float");

            builder.Property(x => x.LastUpdate)
                .IsRequired()
                .HasColumnName("LastUpdate")
                .HasColumnType("DateTimeOffset");

        }
    }
}
