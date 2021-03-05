using Microsoft.EntityFrameworkCore;

namespace SOMS_WebAPI.Models.Context
{
    public class LoginResultContext : DbContext
    {
        public LoginResultContext(DbContextOptions<LoginResultContext> options)
            : base(options)
        {
        }

        public DbSet<LoginResult> LoginResults { get; set; }
    }
}
