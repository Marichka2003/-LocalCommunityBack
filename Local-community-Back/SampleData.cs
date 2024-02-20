using Local_community_Back.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Local_community_Back
{
    public static class SampleData
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedProducts(modelBuilder);
        }

        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            var appeal = new[]
            {
                new Appeal
                {
                    Id = 1,
                    FullName = "Shvets Maria Mukolaivna",
                    Type = Appeal.AppealType.Proposal,
                    Adress = "Chornyi Ostriv, Kvitneva 3",
                    PhoneNumber = 0963561772,
                    Description = "Description",
                    ImageName = "appeal.jpg"
                },

            };

            foreach (var product in appeal)
            {
                // Перевірка, чи існує файл зображення у папці "wwwroot/img"
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", product.ImageName);
                if (!File.Exists(imagePath))
                {
                    // Якщо файл не існує, тоді копіюємо його з початкової папки із зображеннями
                    var sourceImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/original_images", product.ImageName);
                    File.Copy(sourceImagePath, imagePath);
                }

                // Додавання продукту до БД
                modelBuilder.Entity<Appeal>().HasData(product);
            }

        }
    }
}
