
using API.models;
using Microsoft.EntityFrameworkCore;

namespace API.data
{
    public class AppliactionDBcontext : DbContext
    {
        public AppliactionDBcontext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock {get; set;}
        public DbSet<Comment> Comments {get; set;}
    }
}


