using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();
            context.Database.Migrate();

            var genres=new List<Genre>()
                      {
                      new Genre {Name = "Macera",Movies=new List<Movie>()  {new Movie{
                            Title="Yeni Macera Filmi1",
                            Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                            ImageUrl="1.jpg"
                      },
                      new Movie {
                            Title="Yeni Macera Filmi1",
                            Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                            ImageUrl="2.jpg"
                      } } },   
     new Genre { Name = "Savaş" }, new Genre { Name = "Komedi" },new Genre { Name = "Romantik" }
                       };
            var movies = new List<Movie>()
                        {
                            new Movie {
        Title="Jiu Jitsu",
        Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
        ImageUrl="1.jpg",
        Genres =new List<Genre>()
        {
            genres[0],
            new Genre()
            {
                Name="yeni tür"
            },
            genres[1]
        }
    },
    new Movie {
        Title="Fatman",
        Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
        ImageUrl="2.jpg",
         Genres =new List<Genre>()
        {
            genres[0],
            genres[3]
        }

    },
    new Movie {
        Title="The Dalton Gang",
        Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
        ImageUrl="3.jpg",
        Genres =new List<Genre>()
        {
            genres[0],
            genres[1]
        }

    },
        new Movie {
        Title="Tenet",
        Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
        ImageUrl="4.jpg",
        Genres =new List<Genre>()
        {
            genres[1],
            genres[2]
        }

    },
    new Movie {
        Title="The Craft: Legacy",
        Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
        ImageUrl="5.jpg",
        Genres =new List<Genre>()
        {
            genres[3],
            genres[1]
        }
    },
    new Movie {
        Title="Hard Kill",
        Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
        ImageUrl="6.jpg",
        Genres =new List<Genre>()
        {
            genres[1],
            genres[2]
        }
    }
};
            var users = new List<User>() 
            {
                new User() { Username="usera",Email="usera@gmail.com",ImageUrl="person1.jpg"},
                new User() { Username="userb",Email="userb@gmail.com",ImageUrl="person2.jpg"},
                new User() { Username="userc",Email="userc@gmail.com",ImageUrl="person3.jpg"},
                new User() { Username="userd",Email="userd@gmail.com",ImageUrl="person4.jpg"}
                    
            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Personel1",
                    Biography = "tanıtım1",
                    User=users[0]
                },
                new Person()
                {
                    Name = "Personel2",
                    Biography = "tanıtım2",
                    User=users[1]
                }

            };
            var crews = new List<Crew>()
            {
                new Crew(){Movie=movies[0],Person=people[0],Job="Yonetmen"},
                new Crew(){Movie=movies[1],Person=people[1],Job="Yonetmen Yard"}
            };
            var cast = new List<Cast>()
            { new Cast(){Movie=movies[0],Person=people[0],Name="Oyuncu Adı",Character="Karakter 1"},
             new Cast(){Movie=movies[1],Person=people[1], Name="Oyuncu Adı2",Character="Karakter "}
            };
            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Movies.Count()==0)
                {
                    context.Movies.AddRange(movies);                       
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(cast);
                }

                context.SaveChanges();
            }
        }
    }
}
