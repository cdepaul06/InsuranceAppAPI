using Microsoft.EntityFrameworkCore;

namespace InsuranceAppAPI.Models
{
    public partial class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(k => k.CustomerId);
            });

            modelBuilder.Entity<CustomerPolicy>(entity =>
            {
                entity.HasKey(k => k.CustomerPolicyId);
            });

            modelBuilder.Entity<PolicyStatus>(entity =>
            {
                entity.HasKey(k => k.PolicyStatusId);
            });

            modelBuilder.Entity<PolicyType>(entity =>
            {
                entity.HasKey(k => k.PolicyTypeId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(k => k.UserId);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.HasKey(k => k.UserStatusId);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(k => k.UserTypeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
