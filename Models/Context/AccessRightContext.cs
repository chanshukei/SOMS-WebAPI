using Microsoft.EntityFrameworkCore;

namespace SOMS_WebAPI.Models.Context
{
    public class AccessRightContext : DbContext
    {
        public AccessRightContext(DbContextOptions<AccessRightContext> options)
            : base(options)
        {
        }

        public DbSet<AccessRight> AccessRights { get; set; }
    }
}
