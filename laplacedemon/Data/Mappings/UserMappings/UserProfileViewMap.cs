using laplacedemon.Models.UserEnvironment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace laplacedemon.Data.Mappings.UserMappings
{
    public class UserProfileViewMap : IEntityTypeConfiguration<UserProfileView>
    {
        public void Configure(EntityTypeBuilder<UserProfileView> builder)
        {

            // Tabela
            builder.ToTable("UserProfileView");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();


            builder.Property(x => x.UserVisitorId)
                .IsRequired()
                .HasColumnName("UserVisitorId")
                .HasColumnType("int");

            builder.Property(x => x.ViewDate)
                .IsRequired()
                .HasColumnName("ViewDate")
                .HasColumnType("DateTimeOffset");
        }
    }
}
