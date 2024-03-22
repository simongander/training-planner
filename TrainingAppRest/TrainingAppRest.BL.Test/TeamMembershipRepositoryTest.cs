using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppBL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Model;

namespace TrainingAppRest.BL.Test
{
    internal class TeamMembershipRepositoryTest
    {
        private readonly TeamMembershipRepository _teamMembershipRepository;
        public TeamMembershipRepositoryTest()
        {
            ITrainingDbContext dbContext = new TrainingDbContextInMemory();

            var teamMembership = new TeamMembership
            {
                MembershipId = 1,
                TeamId = 1,
                UserId = 1
            };

            dbContext.TeamMembership.Add(teamMembership);
            dbContext.SaveChanges();
            _teamMembershipRepository = new TeamMembershipRepository(dbContext);
        }

        [Test]
        public void GetTeamMembershipsOfUser_Success()
        {
            var memberships = _teamMembershipRepository.GetTeamMembershipsOfUser(1);

            Assert.That(memberships.Count, Is.EqualTo(1));
            Assert.That(memberships.First().TeamId , Is.EqualTo(1));
        }
    }
}
