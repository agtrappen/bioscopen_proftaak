using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bioscoopsysteem.Models;
using Bioscoopsysteem.Data;

namespace Bioscoopsysteem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BioscoopsysteemContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
             new Movie { Title="The Shawshanks", Genre="Drama" ,subtitle="Engels", Description="Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",Actor="Jack",Writting="Daniel", releaseDate=DateTime.Parse("2021-03-19 17:00"), Duration=142},
             new Movie { Title="Redemption (1994)", Genre="Crime" ,subtitle="Nederlands", Description="Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",Actor="Thomas",Writting="Pieter", releaseDate=DateTime.Parse("2021-03-19 17:00"), Duration=142},
             new Movie { Title="Shawshank", Genre="Action" ,subtitle="Nederlands", Description="Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",Actor="Thomas",Writting="Pieter", releaseDate=DateTime.Parse("2021-03-19 17:00"), Duration=142},
             new Movie { Title="Cocomelon", Genre="Kinderfilm" ,subtitle="Nederlands", Description="Cocomelon's videos include children, adults, and animals who interact with each other in daily life. The lyrics appear at the bottom of the screen in the same way on all displays. In 2020",Actor="Brittany Taylor",Writting="Jay Jeon", releaseDate=DateTime.Parse("2021-03-19 17:00"), Duration=142},
              
            };


            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();


                

            var shows = new Show[]
            {
                new Show { Start_date=DateTime.Parse("2021-03-16 14:30"),HallId=1,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-16 14:30"),HallId=2,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-16 15:30"),HallId=3,MovieId=2},
                new Show { Start_date=DateTime.Parse("2021-03-16 15:30"),HallId=4,MovieId=4},
                new Show { Start_date=DateTime.Parse("2021-03-17 15:00"),HallId=5,MovieId=3},

                new Show { Start_date=DateTime.Parse("2021-03-19 17:00"),HallId=1,MovieId=4},
                new Show { Start_date=DateTime.Parse("2021-03-18 17:15"),HallId=2,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-17 18:00"),HallId=3,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-14 18:30"),HallId=4,MovieId=2},
                new Show { Start_date=DateTime.Parse("2021-03-15 18:15"),HallId=5,MovieId=2},
            };
            foreach (Show s in shows)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();

            var arrangements = new Arrangement[]
            {
                new Arrangement { Description="Movie + Popcorn + Soda", Price=10},
                new Arrangement { Description="Movie + Chips+ Soda", Price=10},
                new Arrangement { Description="Movie + VIP+ Soda", Price=12},
                new Arrangement { Description="Movie + VIP + Chips + Soda", Price=15},
                new Arrangement { Description="Movie + Soda", Price=5},
            };

            foreach (Arrangement a in arrangements)
            {
                context.Arrangements.Add(a);
            }
            context.SaveChanges();

        }
    }
}