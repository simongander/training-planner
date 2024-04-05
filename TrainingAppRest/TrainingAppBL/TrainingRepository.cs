using System.Collections.Generic;
using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppModel;

namespace TrainingAppBL
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ITrainingDbContext _context;

        public TrainingRepository(ITrainingDbContext context)
        {
            this._context = context;
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
            this._context.Add(training);
            this._context.SaveChanges();
        }

        public void UpdateTraining(Training training)
        {
            var entity = _context.Training.First(t => t.TrainingId == training.TrainingId);
            entity.Description = training.Description;
            entity.Date = training.Date;
            entity.CreatorId = training.CreatorId;
            entity.TeamId = training.TeamId;
            entity.Place = training.Place;
            entity.TypeId = training.TypeId;
            _context.Training.Update(entity);
            _context.SaveChanges();
        }
    }
}
