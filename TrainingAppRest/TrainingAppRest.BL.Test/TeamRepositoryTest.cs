using TrainingAppDAL.Interfaces;
using TrainingAppDAL;
using TrainingAppBL;
using TrainingAppDAL.Model;

namespace TrainingAppRest.BL.Test
{

    internal class TeamRepositoryTest
    {
        private readonly TeamRepository _teamRepository;

        public TeamRepositoryTest()
        {
            ITrainingDbContext dbContext = new TrainingDbContextInMemory();

            var team = new Team
            {
                TeamId = 1,
                TeamName = "BSV Stans"
            };
            dbContext.Team.Add(team);
            dbContext.SaveChanges();
            _teamRepository = new TeamRepository(dbContext);
        }

        [Test]
        public void GetTeamById_Success()
        {
            var team = _teamRepository.GetTeamById(1);

            Assert.That(team.TeamId == 1 && team.TeamName == "BSV Stans");
        }

        [Test]
        public void GetTeamById_Failure()
        {
            var team = _teamRepository.GetTeamById(2);

            Assert.IsNull(team);
        }
    }
}
