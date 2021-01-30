using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaids.API.Services;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaidsController : ControllerBase
    {
        private IRaidService service;
        public RaidsController(IRaidService service)
        {
            this.service = service;
        }

        [HttpGet("/raid/all")]
        public IList<RaidModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("/raid/{id}")]
        public RaidModel GetRaid(long id)
        {
            return service.Get(id);
        }

        [HttpPost("/raid")]
        public RaidModel Create(RaidDOM model)
        {
            return service.Save(model);
        }
        [HttpDelete("/raid/{raidId}/{userId}")]
        public void Delete(long raidId, long userId)
        {
            service.Delete(raidId, userId);
        }
        [HttpPatch("/raid/join/{raidId}/{userId}")]
        public void JoinRaid(long raidId, long userId)
        {
            service.AddUserToContenders(raidId, userId);
        }
        [HttpPatch("/raid/leave/{raidId}/{userId}")]
        public void LeaveRaid(long raidId, long userId)
        {
            service.RemoveUserFromContenders(raidId, userId);
        }
    }
}
