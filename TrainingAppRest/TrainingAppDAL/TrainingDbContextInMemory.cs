using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppDAL.Interfaces;
using TrainingAppModel;

namespace TrainingAppDAL
{
    public class TrainingDbContextInMemory : DbContext, ITrainingDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TrainingDb");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Training> Training { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMembership> TeamMembership { get; set; }
        public DbSet<TrainingType> TrainingType { get; set; }
        public DbSet<User> User { get; set; }
    }
}
