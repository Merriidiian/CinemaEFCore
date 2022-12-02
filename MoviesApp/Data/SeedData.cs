using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding Database");
            using (var context =
                   new MoviesContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesContext>>()))
            {
                // Look for any movies.
                if (context.Actors.Any())
                {
                    return; // DB has been seeded
                }
                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "John",
                        Surname = "Depp",
                        BirthDate = DateTime.Parse("1962-9-6")
                    },
                    new Actor
                    {
                        Name = "Leonardo",
                        Surname = "DiCaprio",
                        BirthDate = DateTime.Parse("1972-11-11")
                    },
                    new Actor
                    {
                        Name = "Willard",
                        Surname = "Smith",
                        BirthDate = DateTime.Parse("1968-9-25")
                    },
                    new Actor
                    {
                        Name = "James",
                        Surname = "Carrey",
                        BirthDate = DateTime.Parse("1962-1-17")
                    }
                );

                context.SaveChanges();
                
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return; // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );

                context.SaveChanges();
            }
        }
    }
}