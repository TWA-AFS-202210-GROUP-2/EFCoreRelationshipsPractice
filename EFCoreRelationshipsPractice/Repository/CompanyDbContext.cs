using EFCoreRelationshipsPractice.models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Repository
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }
        public DbSet<CompanyEntity> Companies { get; set; }

        public DbSet<ProfileEntity> profiles { get; set; }

        public DbSet<EmployeeEntity> Employee { get; set; }
    }
}