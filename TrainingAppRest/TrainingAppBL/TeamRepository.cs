using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppBL
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TrainingDbContext _context;

        public TeamRepository(ITrainingDbContext context)
        {
            this._context = context as TrainingDbContext;
        }

        public Team GetTeamById(int id)
        {
            return this._context.Team.FirstOrDefault(x => x.TeamId == id);
        }
    }
}
