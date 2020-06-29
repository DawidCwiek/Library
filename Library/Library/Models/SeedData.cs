using Library.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryContext>>()))
            {
                
                if (!context.Book.Any())
                {
                    context.Book.AddRange(
                        new Book
                        {
                            Title = "When Harry Met Sally",
                            Author = "Jakiś autor",
                            PublishingHouse = "Jakieś wydawnictwo",
                            ReleaseDate = DateTime.Parse("1989-2-12"),

                        }
                    );

                    context.SaveChanges();
                }

               
            }
        }
    }
}
