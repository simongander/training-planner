using Microsoft.EntityFrameworkCore;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppDAL
{
    public class TrainingDbContext : DbContext, ITrainingDbContext
    {
        private readonly string _connectionString;

        public TrainingDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Method intentionally left empty.
        }

        public DbSet<Training> Training { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMembership> TeamMembership { get; set; }
        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<User> User { get; set; }
    }
}
