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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
