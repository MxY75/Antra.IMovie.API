using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Antra.IMovie.Core.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Antra.IMovie.Infrascruture.Data
{
    public class IMovieCrmDBContext : IdentityDbContext<AppUser,IdentityRole<int>, int>

    {

        //Why we are doing it connection string in mvc objct 
        // and movie is in infastructuer so we need to pass it into infastructre obj
        //but infastructure i
        public IMovieCrmDBContext(DbContextOptions<IMovieCrmDBContext> options) : base(options)
        {
        }

        public DbSet<Cast> Cast { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<AppUser> AppUser {get;set;}
        public DbSet<Genre> Genre { get; set; }

        public DbSet<MovieGenre> MovieGenre { get; set; }

        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Review> Review{ get; set; }

        public DbSet<Trailer> Trailer { get; set; }




    }
}
