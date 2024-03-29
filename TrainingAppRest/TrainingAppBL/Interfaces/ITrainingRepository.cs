﻿using System.Collections.Generic;
using TrainingAppDAL.Model;

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
