using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrainingAppModel;

namespace TrainingAppDAL.Interfaces
{
    public interface ITrainingDbContext
    {
        DbSet<Training> Training { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<TeamMembership> TeamMembership { get; set; }
        DbSet<TrainingType> TrainingType { get; set; }
        DbSet<User> User { get; set; }
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
