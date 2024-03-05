using System;
using System.Collections.Generic;
using System.Text;
using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface ITrainingTypeRepository
    {
        List<TrainingType> GetAllTypes();
    }
}
