using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wio.Booking.Business.Models;

namespace Wio.Booking.Data.Mappings;

public class CarRentalMapping : IEntityTypeConfiguration<CarRental>
{
    public void Configure(EntityTypeBuilder<CarRental> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnType("varchar(1000)");

        builder.Property(p => p.Image)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(p => p.Value)
            .HasColumnType("decimal")
            .HasPrecision(5);

        builder.ToTable("Cars");
    }
}