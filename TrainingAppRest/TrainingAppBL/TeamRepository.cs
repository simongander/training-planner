using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppBL
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ITrainingDbContext _context;

        public TeamRepository(ITrainingDbContext context)
        {
            this._context = context;
        }

        public Team GetTeamById(int id)
        {
            return this._context.Team.FirstOrDefault(x => x.TeamId == id);
        }
    }
}
