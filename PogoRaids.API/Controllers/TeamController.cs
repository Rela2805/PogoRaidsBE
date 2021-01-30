using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaids.API.Services;
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
        private ITeamService service;

        public TeamController(ITeamService service)
        {
            this.service = service;
        }

        [HttpGet("/team/{id}")]
        public TeamModel GetTeam(long id)
        {
            return service.Get(id);
        }

        [HttpGet("/team/all")]
        public IList<TeamModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost("/team")]
        public TeamModel Create(TeamColorDOM teamModel)
        {
            return service.Create(teamModel);
        }

        [HttpDelete("/team/{id}")]
        public void Delete(long id)
        {
            service.Delete(id);
        }

    }
}
