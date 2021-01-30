using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface IUserService
    {
        IList<UserModel> GetAll();
        UserModel Get(long id);
        UserModel Create(UserDOM model);
        UserModel Login(string password, string email);
        void Delete(long id);
        void Update(long id, UserDOM model);
        IList<UserModel> GetMostActive();
    }
}
