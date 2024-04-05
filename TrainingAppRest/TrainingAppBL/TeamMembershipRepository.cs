using System.Collections.Generic;
using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppModel;

namespace TrainingAppBL
{
    public class TeamMembershipRepository : ITeamMembershipRepository
    {
        private readonly ITrainingDbContext _context;

        public TeamMembershipRepository(ITrainingDbContext context)
        {
            this._context = context;
        }

        public List<TeamMembership> GetTeamMembershipsOfUser(int userId)
        {
            return this._context.TeamMembership
                .Where(x => x.UserId == userId)
                .ToList();
        }
    }
}
