using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Question2.Models;

namespace Question2.Models
{
    
    


        public class MoviesDbContext : DbContext
        {
         
        public MoviesDbContext() : base("name=connectstr") { }

        public DbSet<Movy> Movies { get; set; }
        }

    }
