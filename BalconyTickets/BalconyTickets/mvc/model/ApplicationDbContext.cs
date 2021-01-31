using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BalconyTickets.mvc.model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }

        public DbSet<User> User { get; set; }

        public DbSet<Queue> Queue { get; set; }

        public DbSet<Balcony> Balcony { get; set; }        

        public DbSet<vwQueue> vwQueue { get; set; }
    
    }
}
