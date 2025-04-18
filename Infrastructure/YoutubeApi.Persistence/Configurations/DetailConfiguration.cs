using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Detail detail1 = new()
            {
                Id = 1,
                Title = "Giriş Bilgileri",
                Description = "Bu kategoriye ait temel bilgiler burada yer alır.",
                CategoryId = 1,
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = false,
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = "Bilgisayar Detayları",
                Description = "Donanım, yazılım ve aksesuar bilgileri.",
                CategoryId = 3,
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = true,
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = "Kadın Giyim Açıklaması",
                Description = "Moda ve stil üzerine detaylı açıklamalar.",
                CategoryId = 4,
                CreateDate = new DateTime(2024, 01, 01),
                IsDeleted = false,
            };

            builder.HasData(detail1, detail2, detail3);

        }
    }
}
