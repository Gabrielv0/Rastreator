using Microsoft.EntityFrameworkCore;

namespace coreApi.Context
{
    public class coreApiContext:DbContext
    {
        public coreApiContext(DbContextOptions<coreApiContext> options):base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
