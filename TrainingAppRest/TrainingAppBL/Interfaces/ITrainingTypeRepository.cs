using System.Collections.Generic;
using TrainingAppModel;

namespace TrainingAppBL.Interfaces
{
    public interface ITrainingTypeRepository
    {
        List<TrainingType> GetAllTypes();
    }
}
