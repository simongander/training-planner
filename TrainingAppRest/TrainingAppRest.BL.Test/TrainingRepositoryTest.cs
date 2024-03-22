using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppBL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Model;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Crypto.Prng;

namespace TrainingAppRest.BL.Test
{
    internal class TrainingRepositoryTest
    {
        private readonly TrainingRepository _trainingRepository;

        public TrainingRepositoryTest()
        {
            ITrainingDbContext dbContext = new TrainingDbContextInMemory();
            _trainingRepository = new TrainingRepository(dbContext);
            var training = new Training
            {
                TrainingId = 1,
                Description = "Lauftraining",
                Place = "Stans",
                Date = DateTime.Now,
                TypeId = 1,
                TeamId = null,
                CreatorId = 1
            };
            var teamTraining = new Training
            {
                TrainingId = 2,
                Description = "Krafttraining",
                Place = "Stans",
                Date = DateTime.Now,
                TypeId = 1,
                TeamId = 1,
                CreatorId = 1
            };
            _trainingRepository.CreateTraining(training);
            _trainingRepository.CreateTraining(teamTraining);
        }

        [Test]
        [Order(1)]
        public void GetAllTrainingsOfUser_Success()
        {
            var trainings = _trainingRepository.GetTrainingsOfUser(1);

            Assert.That(trainings.Count() == 1);
            Assert.That(trainings.First().CreatorId == 1);
        }

        [Test]
        [Order(2)]
        public void GetAllTrainingsOfUser_Failure()
        {
            var trainings = _trainingRepository.GetTrainingsOfUser(2);

            Assert.That(trainings.Count() == 0);
        }

        [Test]
        [Order(3)]
        public void GetAllTrainingsOfTeam_Success()
        {
            var trainings = _trainingRepository.GetTrainingsOfTeam(1);

            Assert.That(trainings.Count() == 1);
            Assert.That(trainings.First().TeamId == 1);
        }

        [Test]
        [Order(4)]
        public void GetAllTrainingsOfTeam_Failure()
        {
            var trainings = _trainingRepository.GetTrainingsOfTeam(2);

            Assert.That(trainings.Count() == 0);
        }

        [Test]
        [Order(5)]
        public void CreateAndUpdateTraining_Success()
        {
            var training = new Training
            {
                TrainingId = 3,
                Description = "Lauftraining",
                Place = "Stans",
                Date = DateTime.Now,
                TypeId = 1,
                TeamId = null,
                CreatorId = 2
            };
            var newTraining = new Training
            {
                TrainingId = 3,
                Description = "Krafttraining",
                Place = "Stans",
                Date = DateTime.Now,
                TypeId = 1,
                TeamId = null,
                CreatorId = 2
            };

            _trainingRepository.CreateTraining(training);
            _trainingRepository.UpdateTraining(newTraining);

            Assert.That(_trainingRepository.GetTrainingsOfUser(2).First().Description == "Krafttraining");
        }
    }
}
