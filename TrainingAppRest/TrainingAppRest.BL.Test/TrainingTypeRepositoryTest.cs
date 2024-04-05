using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL;
using TrainingAppModel;
using TrainingAppBL;

namespace TrainingAppRest.BL.Test
{
    internal class TrainingTypeRepositoryTest
    {
        private readonly TrainingTypeRepository _trainingTypeRepository;

        public TrainingTypeRepositoryTest()
        {
            ITrainingDbContext dbContext = new TrainingDbContextInMemory();
            var trainingType = new TrainingType
            {
                TypeId = 1,
                ImageName = "Run.jpeg",
                Name = "Lauftraining"
            };
            dbContext.Add(trainingType);
            dbContext.SaveChanges();

            _trainingTypeRepository = new TrainingTypeRepository(dbContext);
        }

        [Test]
        public void GetAllTypes_Success()
        {
            var types = _trainingTypeRepository.GetAllTypes();

            Assert.That(types.Count, Is.EqualTo(1));
            Assert.That(types.First().Name, Is.EqualTo("Lauftraining"));
        }
    }
}
