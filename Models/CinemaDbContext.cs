using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Cinema.Web.Models
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<List> Lists { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public CinemaDbContext(DbContextOptions options) : base(options)
        {

        }

        
    }
}
