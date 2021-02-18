using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lucaci_Ioana_ProiectFinal.Models;

namespace Lucaci_Ioana_ProiectFinal.Data
{
    public class Lucaci_Ioana_ProiectFinalContext : DbContext
    {
        public Lucaci_Ioana_ProiectFinalContext (DbContextOptions<Lucaci_Ioana_ProiectFinalContext> options)
            : base(options)
        {
        }

        public DbSet<Lucaci_Ioana_ProiectFinal.Models.Article> Article { get; set; }

        public DbSet<Lucaci_Ioana_ProiectFinal.Models.Author> Author { get; set; }

        public DbSet<Lucaci_Ioana_ProiectFinal.Models.Category> Category { get; set; }
    }
}
