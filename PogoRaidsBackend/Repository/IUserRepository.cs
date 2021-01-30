using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public interface IUserRepository
    {
        UserDataModel Get(long id);
        IList<UserDataModel> GetAll();
        UserDataModel Save(UserDataModel userModel);
        UserDataModel Login(string password, string email);
        void Delete(long id);
        void Update(long id, string name, string surname, string username, string gameNickname, string email, string password, int level);
        IList<UserDataModel> GetMostActive();
    }
}
