using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<AccountRoleLinkEntity> AccountRoleLinks { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasKey(arl => new { arl.AccountId, arl.RoleId });

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Account)
                .WithMany(a => a.RolesLink)
                .HasForeignKey(arl => arl.AccountId);

            modelBuilder.Entity<AccountRoleLinkEntity>()
                .HasOne(arl => arl.Role)
                .WithMany(r => r.AccountsLink)
                .HasForeignKey(arl => arl.RoleId);
        }
    }
}