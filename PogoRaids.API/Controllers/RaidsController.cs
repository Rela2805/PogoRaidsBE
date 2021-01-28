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
        public IList<RaidDataModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("/raid/{id}")]
        public RaidDataModel GetRaid(long id)
        {
            return service.Get(id);
        }

        [HttpPost("/raid")]
        public RaidDataModel Create(RaidDOM model)
        {
            return service.Save(model);
        }
    }
}
