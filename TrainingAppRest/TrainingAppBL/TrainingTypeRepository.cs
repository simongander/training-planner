using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingAppBL.Interfaces;
using TrainingAppDAL;
using TrainingAppDAL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppBL
{
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly TrainingDbContext _context;

        public TrainingTypeRepository(ITrainingDbContext context)
        {
            this._context = context as TrainingDbContext;
        }

        public List<TrainingType> GetAllTypes()
        {
            return this._context.TrainingType.ToList();
        }
    }
}
