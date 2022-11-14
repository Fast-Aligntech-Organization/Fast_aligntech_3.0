#define _TEST_
#undef _TEST_

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Fast.Core;

namespace Fast.Infrastructure.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<PrivateUser>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if _TEST_
            if (!optionsBuilder.IsConfigured)
            {
               
            }
#endif


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrivateUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");


        }


    }
}

