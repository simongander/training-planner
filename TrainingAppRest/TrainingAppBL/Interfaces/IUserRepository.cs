using System;
using System.Collections.Generic;
using System.Text;
using TrainingAppDAL.Model;

namespace TrainingAppBL.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        string Authenticate(string credString);
        void CreateUser(string credString);
    }
}
