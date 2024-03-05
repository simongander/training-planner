using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TrainingAppDAL.Model;

namespace TrainingAppDAL.Interfaces
{
    public interface ITrainingDbContext
    {
        DbSet<Training> Training { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<TeamMembership> TeamMembership { get; set; }
        DbSet<TrainingType> TrainingType { get; set; }
        DbSet<User> User { get; set; }
    }
}
