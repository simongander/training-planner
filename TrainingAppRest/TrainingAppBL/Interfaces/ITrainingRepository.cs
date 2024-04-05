using System.Collections.Generic;
using TrainingAppModel;

namespace TrainingAppBL.Interfaces
{
    public interface ITrainingRepository
    {
        List<Training> GetTrainingsOfUser(int userId);
        List<Training> GetTrainingsOfTeam(int teamId);
        void CreateTraining(Training training);
        void UpdateTraining(Training training);
    }
}
