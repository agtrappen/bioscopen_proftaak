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
                new Movie { Title="The Shawshank Redemption (1994)", Genre="Drama", Description="Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Duration=142},
                new Movie { Title="The Godfather (1972)", Genre="Crime, Drama", Description="An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.", Duration=175},
                new Movie { Title="The Godfather: Part II (1974)", Genre="Crime, Drama", Description="The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", Duration=202},
                new Movie { Title="The Dark Knight (2008)", Genre="Action, Crime, Drama", Description="descrWhen the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.iption", Duration=152},
                new Movie { Title="12 Angry Men (1957)", Genre="Crime, Drama", Description="A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.", Duration=96},
            };


            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();


            TimeSpan timeSpan = new TimeSpan(2, 14, 18);
            Console.WriteLine(timeSpan.ToString());

            var shows = new Show[]
            {
                new Show { Start_date=DateTime.Parse("2021-03-16 16:00"),HallId=1,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-16 17:00"),HallId=2,MovieId=1},
                new Show { Start_date=DateTime.Parse("2021-03-16 18:00"),HallId=3,MovieId=2},
                new Show { Start_date=DateTime.Parse("2021-03-16 19:00"),HallId=4,MovieId=4},
                new Show { Start_date=DateTime.Parse("2021-03-16 20:00"),HallId=5,MovieId=3},
            };
            foreach (Show s in shows)
            {
                context.Shows.Add(s);
            }
            context.SaveChanges();

            var tariffs = new Tariff[]
            {
                new Tariff {Name="Standaard ticket", Price=9.00M},
                new Tariff {Name="65+ ticket", Price=7.50M},
                new Tariff {Name="Jongerenticket (CJP)", Price=8.00M}
            };
            foreach(Tariff t in tariffs)
            {
                context.Tariffs.Add(t);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer {Name="Henk Jansen", Email="henk@jansen.nl"}
            };
            foreach(Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var tickets = new Ticket[]
            {
                new Ticket {ShowId=1, SeatId=1, CustomerId=1, Date_sold=DateTime.Parse("2021-03-16 16:00"), TariffId=1}
            };
            foreach(Ticket t in tickets)
            {
                context.Tickets.Add(t);
            }
            context.SaveChanges();
        }
    }
}