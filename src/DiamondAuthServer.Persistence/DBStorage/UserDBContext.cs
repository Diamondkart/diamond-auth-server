using DiamondAuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiamondAuthServer.Persistence.DBStorage
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public DbSet<UserDetail> Users { get; set; }
        public DbSet<ChangePassword> ChangePassword { get; set; }
    }
}