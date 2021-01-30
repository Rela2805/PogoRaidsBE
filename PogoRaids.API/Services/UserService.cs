using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public class UserService : IUserService
    {
        private ITeamRepository TeamRepository;
        private IUserRepository UserRepository;

        public UserService(ITeamRepository TeamRepository, IUserRepository UserRepository)
        {
            this.TeamRepository = TeamRepository;
            this.UserRepository = UserRepository;
        }
        public UserModel Create(UserDOM model)
        {
            var team = TeamRepository.GetByColor(model.Color);
            var user = new UserDataModel { Name = model.Name, Email = model.Email, GameCode = model.GameCode, GameNickname = model.GameNickname, Level = model.Level, Password = model.Password, Surname = model.Surname, Username = model.Username, Team = team, RaidsCompleted = 0 };
            team.Members.Add(user);

            return new UserModel(UserRepository.Save(user));
        }

        public UserModel Get(long id)
        {
            return new UserModel(UserRepository.Get(id));
        }

        public IList<UserModel> GetAll()
        {
            return UserRepository.GetAll().Select(x => new UserModel(x)).ToList();
        }

        public UserModel Login(string password, string email)
        {
            return new UserModel(UserRepository.Login(password, email));
        }
        public void Delete(long id)
        {
            UserRepository.Delete(id);
        }
        public void Update(long id, UserDOM model)
        {
            UserRepository.Update(id, model.Name, model.Surname, model.Username, model.GameNickname, model.Email, model.Password, model.Level);
        }
        public IList<UserModel> GetMostActive()
        {
            return UserRepository.GetMostActive().Select(x => new UserModel(x)).ToList();
        }
    }
}
