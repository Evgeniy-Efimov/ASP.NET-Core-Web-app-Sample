using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.Models;
using WebApp.Settings;

namespace WebApp.DAL
{
    public class DB1DataContext : DbContext
    {
        private string ConnectionString { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DB1DataContext(IOptions<ConnectionString> connectionStrings)
        {
            ConnectionString = connectionStrings.Value.DB1ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //computed fields
            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasComputedColumnSql("[FirstName] + RTRIM(' ' + ISNULL([LastName], ''))");

            //foreign keys
            modelBuilder.Entity<DocumentType>()
                .HasMany(dt => dt.Documents)
                .WithOne(d => d.DocumentType)
                .HasForeignKey(d => d.DocumentTypeId);

            //many with many relations
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(ur => ur.ToTable("UserRoles"));

            //indexes
            modelBuilder.Entity<Document>(entity => entity.HasIndex(d => new { d.BarCode, d.RegNumber }).IsUnique());
        }
    }
}
