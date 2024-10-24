using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hoos_Ana_Lab2V5.Models;

namespace Hoos_Ana_Lab2V5.Data
{
    public class Hoos_Ana_Lab2V5Context : DbContext
    {
        public Hoos_Ana_Lab2V5Context (DbContextOptions<Hoos_Ana_Lab2V5Context> options)
            : base(options)
        {
        }

        public DbSet<Hoos_Ana_Lab2V5.Models.Book> Book { get; set; } = default!;
        public DbSet<Hoos_Ana_Lab2V5.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Hoos_Ana_Lab2V5.Models.Author> Author { get; set; } = default!;
        public DbSet<Hoos_Ana_Lab2V5.Models.Category> Category { get; set; } = default!;
    }
}
