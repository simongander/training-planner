using System;
using System.Collections.Generic;
using System.Text;
using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface ITeamMembershipRepository
    {
        List<TeamMembership> GetTeamMembershipsOfUser(int userId);
    }
}
