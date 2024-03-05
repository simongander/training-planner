using System.Collections.Generic;
using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface ITrainingTypeRepository
    {
        List<TrainingType> GetAllTypes();
    }
}
