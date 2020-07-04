using Library.Areas.Identity.Data;
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
                            Title = "Czysty kod. Podręcznik dobrego programisty",
                            Author = "Robert C. Martin",
                            PublishingHouse = "Wydawnictwo Helion",
                            ReleaseDate = DateTime.Parse("2014-15-10"),

                        },
                        new Book
                        {
                            Title = "Czysty kod w Pythonie",
                            Author = "Kapil Sunil",
                            PublishingHouse = "Wydawnictwo Helion",
                            ReleaseDate = DateTime.Parse("2020-12-05"),

                        },
                        new Book
                        {
                            Title = "Python. Leksykon kieszonkowy",
                            Author = "Lutz Mark",
                            PublishingHouse = "Wydawnictwo Helion",
                            ReleaseDate = DateTime.Parse("2019-08-08"),

                        },
                        new Book
                        {
                            Title = "Linux. Komendy i polecenia",
                            Author = "Sosna Łukasz",
                            PublishingHouse = "Wydawnictwo Helion",
                            ReleaseDate = DateTime.Parse("2018-29-08"),
                        },
                        new Book
                        {
                            Title = "Język Python dla nastolatków. Zabawa w programowanie",
                            Author = "Wiszniewski Michał",
                            PublishingHouse = "Wydawnictwo Helion",
                            ReleaseDate = DateTime.Parse("2017-14-04"),

                        },
                        new Book
                        {
                            Title = "Personal Cybersecurity",
                            Author = "Marvin Waschke",
                            PublishingHouse = "Apress",
                            ReleaseDate = DateTime.Parse("2018-14-07"),

                        },
                        new Book
                        {
                            Title = "Practical Cryptography in Python",
                            Author = "Seth James Nielson, Christopher K. Monson",
                            PublishingHouse = "Apress",
                            ReleaseDate = DateTime.Parse("2018-05-27"),

                        },
                        new Book
                        {
                            Title = "Applied Cryptography in .NET and Azure Key Vault",
                            Author = "Stephen Haunts",
                            PublishingHouse = "Apress",
                            ReleaseDate = DateTime.Parse("2017-11-21"),

                        },
                        new Book
                        {
                            Title = "Hello! Raspberry Pi",
                            Author = "Ryan Heitz",
                            PublishingHouse = "Manning Publications",
                            ReleaseDate = DateTime.Parse("2019-01-12"),

                        },
                        new Book
                        {
                            Title = "Get Programming with Python in Motion",
                            Author = "Ana Bell",
                            PublishingHouse = "Manning Publications",
                            ReleaseDate = DateTime.Parse("2018-05-08"),

                        },
                        new Book
                        {
                            Title = "Beginning Programming For Dummies",
                            Author = "Wallace Wang",
                            PublishingHouse = "John Wiley & Sons Inc",
                            ReleaseDate = DateTime.Parse("2006-12-01"),

                        },
                        new Book
                        {
                            Title = "Python For Dummies",
                            Author = "Stef Maruch",
                            PublishingHouse = "John Wiley & Sons Inc",
                            ReleaseDate = DateTime.Parse("2006-06-08"),

                        }
                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
