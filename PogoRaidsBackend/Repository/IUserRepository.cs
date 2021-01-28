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
    }
}
