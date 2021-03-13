using Microsoft.EntityFrameworkCore;
using SOMS_WebAPI.Models;

namespace SOMS_WebAPI.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<LoginResult> LoginResults { get; set; }
        public DbSet<SelectOption> SelectOptions { get; set; }
        public DbSet<SOMS_WebAPI.Models.Customer> Customer { get; set; }
    }
}
