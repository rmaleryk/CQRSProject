using CQRSProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CQRSProject.DataAccess.Write.Database.Configurations
{
    internal class UserLocationConfig : IEntityTypeConfiguration<UserLocation>
    {
        public void Configure(EntityTypeBuilder<UserLocation> builder)
        {
            builder.ToTable("UserLocations");
            builder.Property(userLocation => userLocation.Id).HasColumnName("Id");
            builder.HasKey(userLocation => userLocation.Id);

            builder.Property(userLocation => userLocation.Date)
                .HasColumnName("Date")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(userLocation => userLocation.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(userLocation => userLocation.Latitude)
                .HasColumnName("Latitude")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(userLocation => userLocation.Longitude)
                .HasColumnName("Longitude")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(userLocation => userLocation.Height)
                .HasColumnName("Height")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}