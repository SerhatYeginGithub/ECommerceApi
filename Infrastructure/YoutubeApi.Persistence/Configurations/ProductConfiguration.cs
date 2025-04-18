using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Product product1 = new()
            {
                Id = 1,
                Title = "Kablosuz Kulaklık",
                Description = "Yüksek ses kalitesi ve uzun pil ömrü ile kablosuz kulaklık.",
                BrandId = 1,
                Discount = 5.0m,
                Price = 299.99m,
                IsDeleted = false,
                CreateDate = new DateTime(2024, 01, 01)
            };

            Product product2 = new()
            {
                Id = 2,
                Title = "Dizüstü Bilgisayar",
                Description = "Yüksek performanslı işlemcisiyle ideal bir iş bilgisayarı.",
                BrandId = 3,
                Discount = 8.0m,
                Price = 8499.50m,
                IsDeleted = false,
                CreateDate = new DateTime(2024, 01, 01)
            };

            builder.HasData(product1, product2);
        }
    }
}
