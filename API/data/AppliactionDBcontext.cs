
using API.models;
using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.data
{
    public class AppliactionDBcontext : IdentityDbContext<AppUser>
    {
        public AppliactionDBcontext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock {get; set;}
        public DbSet<Comment> Comments {get; set;}
    }
}


