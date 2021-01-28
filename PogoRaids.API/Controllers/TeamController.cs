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
    public class TeamController : ControllerBase
    {
        private ITeamRepository repository;

        public TeamController(ITeamRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/team/{id}")]
        public TeamDataModel GetTeam(long id)
        {
            return repository.Get(id);
        }

        [HttpGet("/team/all")]
        public IList<TeamDataModel> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPost("/team")]
        public TeamDataModel Create(TeamColorDOM teamModel)
        {
            var team = new TeamDataModel() { Color = teamModel.Color };
            return repository.Save(team);
        }

        [HttpDelete("/team/{id}")]
        public void Delete(long id)
        {
            repository.Delete(id);
        }

    }
}
