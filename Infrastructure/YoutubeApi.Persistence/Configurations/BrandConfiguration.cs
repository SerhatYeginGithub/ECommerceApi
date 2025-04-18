using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Brand brand1 = new Brand
            {
                Id = 1,
                Name = "Arçelik",
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = false
            };
            Brand brand2 = new Brand
            {
                Id = 2,
                Name = "Vestel",
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = false
            };
            Brand brand3 = new Brand
            {
                Id = 3,
                Name = "LC Waikiki",
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = true
            };

            builder.HasData(brand1, brand2, brand3);
        }
    }
}
