using IPA_test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPA_test.Data
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Bill",LastName="Gates",DateOfBirth=DateTime.Parse("1955-10-28")},
            new User{FirstName="Hans",LastName="Muster",DateOfBirth=DateTime.Parse("1980-10-28")},
            new User{FirstName="DEF",LastName="ABC",DateOfBirth=DateTime.Parse("1955-10-28")},
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var rents = new Rent[]
            {
            new Rent{Start=DateTime.Parse("2020-10-01"),End=DateTime.Parse("2020-10-14"),User=users[0]},
            new Rent{Start=DateTime.Parse("2020-09-01"),End=DateTime.Parse("2020-09-14"),User=users[0]},
            new Rent{Start=DateTime.Parse("2020-08-01"),End=DateTime.Parse("2020-08-14"),User=users[1]},
            new Rent{Start=DateTime.Parse("2020-08-15"),End=DateTime.Parse("2020-08-30"),User=users[1]},

            };
            foreach (Rent e in rents)
            {
                context.Rents.Add(e);
            }
            context.SaveChanges();

            var images = new Image[]
            {
                new Image{Src="/assets/haus1/haus1_aussen.jpg",IsThub=true},
                new Image{Src="/assets/haus1/haus1_room1.jpg",IsThub=false},
                new Image{Src="/assets/haus1/haus1_room2.jpg",IsThub=false},
                new Image{Src="/assets/haus2/haus2_aussen.jpg",IsThub=true},
                new Image{Src="/assets/haus2/haus2_room2.jpg",IsThub=false},
                new Image{Src="/assets/haus2/haus2_room1.jpg",IsThub=false},
            };
            foreach (Image i in images)
            {
                context.Images.Add(i);
            }
            context.SaveChanges();

            var houses = new House[]
            {
                new House
                    {
                        Name = "Haus 1",
                        Images = images.Where(i => i.Src.Contains("haus1")).ToList(),
                        Ortschaft = "9999 Arsch der Weltingen",
                        Street = "Landstrasse 1",
                        DetailText = "Genisen sie die Natur in unserem wunderschönen 7 Zimmer Haus in arsch der Weltingen\n"
                        + "Dieses Haus ist wunderschön und überhaupt nicht neben einer Autobahn\n"
                        + "Sie haben super Anschlüsse an die Zivilisation nur 10 Minuten bis zum nächsten Dorf\n",
                        Rents = new List<Rent> {rents[0], rents[2]}
                },
                 new House
                    {
                        Name = "Haus 2",
                        Images = images.Where(i => i.Src.Contains("haus2")).ToList(),
                        Ortschaft = "666 Hell",
                        Street = "Ofenstrasse 17",
                        DetailText = "Mieten sie jetzt ihr Traumhaus direkt an der ofenstrasse 17 in 666 Hölle\n" +
                        "In diesem Haus werden ihre schlimmsten Alpträume wahr",
                        Rents = new List<Rent> {rents[1], rents[3]}
                }
            };
            foreach (House c in houses)
            {
                context.Houses.Add(c);
            }
            context.SaveChanges();
        }
    }
}
