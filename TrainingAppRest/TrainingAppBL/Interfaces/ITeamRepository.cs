using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface ITeamRepository
    {
        Team GetTeamById(int id);
    }
}
