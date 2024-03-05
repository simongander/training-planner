using System.Collections.Generic;
using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppBL
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingDbContext _context;

        public TrainingRepository(ITrainingDbContext context)
        {
            this._context = context as TrainingDbContext;
        }

        public List<Training> GetTrainingsOfUser(int userId)
        {
            return this._context.Training
                .Where(x => x.CreatorId == userId)
                .Where(x => x.TeamId == null)
                .ToList();
        }

        public List<Training> GetTrainingsOfTeam(int teamId)
        {
            return this._context.Training
                .Where(x => x.TeamId == teamId)
                .ToList();
        }

        public void CreateTraining(Training training)
        {
            this._context.Training.Add(training);
            this._context.SaveChanges();
        }

        public void UpdateTraining(Training training)
        {
            this._context.Training.Update(training);
            this._context.SaveChanges();
        }
    }
}
