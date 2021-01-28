using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.DOMModels;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        private ITeamRepository teamRepository;
        public UserController(IUserRepository userRepository, ITeamRepository teamRepository)
        {
            this.userRepository = userRepository;
            this.teamRepository = teamRepository;
        }
        [HttpGet("/user/all")]
        public IList<UserDataModel> GetAll()
        {
            return userRepository.GetAll();
        }

        [HttpGet("/user/{id}")]
        public UserDataModel GetRaid(long id)
        {
            return userRepository.Get(id);
        }

        [HttpPost("/user")]
        public UserDataModel Create(UserDOM model)
        {
            var team = teamRepository.GetByColor(model.Color);
            var user = new UserDataModel { Name = model.Name, Email = model.Email, GameCode = model.GameCode, GameNickname = model.GameNickname, Level = model.Level, Password = model.Password, Surname = model.Surname, Username = model.Username, Team = team, RaidsCompleted = 0 };
            team.Members.Add(user);

            return userRepository.Save(user);
        }
    }
}
