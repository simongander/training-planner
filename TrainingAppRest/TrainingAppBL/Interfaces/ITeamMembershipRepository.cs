using System.Collections.Generic;
using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface ITeamMembershipRepository
    {
        List<TeamMembership> GetTeamMembershipsOfUser(int userId);
    }
}
