using System.Collections.Generic;
using System.Linq;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppModel;

namespace TrainingAppBL
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly ITrainingDbContext _context;

        public TrainingTypeRepository(ITrainingDbContext context)
        {
            this._context = context;
        }

        public List<TrainingType> GetAllTypes()
        {
            return this._context.TrainingType.ToList();
        }
    }
}
