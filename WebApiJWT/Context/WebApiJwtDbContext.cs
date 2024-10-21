using Microsoft.EntityFrameworkCore;
using WebApiJWT.Entities;

namespace WebApiJWT.Context
{
    public class WebApiJwtDbContext:DbContext
    {
        public WebApiJwtDbContext(DbContextOptions<WebApiJwtDbContext> options):base(options)
        {
            
        }
        public DbSet<UserEntitiy> Users => Set<UserEntitiy>();
    }
}
