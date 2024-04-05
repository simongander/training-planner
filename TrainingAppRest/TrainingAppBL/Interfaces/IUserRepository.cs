using TrainingAppModel;

namespace TrainingAppBL.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        string Authenticate(string credString);
        void CreateUser(string credString);
    }
}
