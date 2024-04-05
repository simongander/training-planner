using System.Collections.Generic;
using TrainingAppModel;

namespace TrainingAppBL.Interfaces
{
    public interface ITeamMembershipRepository
    {
        List<TeamMembership> GetTeamMembershipsOfUser(int userId);
    }
}
