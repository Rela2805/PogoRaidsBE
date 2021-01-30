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
    public class DifficultyController : ControllerBase
    {
        private IDifficultyService service;

        public DifficultyController(IDifficultyService service)
        {
            this.service = service;
        }

        [HttpGet("/difficulty/{id}")]
        public DifficultyModel GetDifficulty(long id)
        {
            return service.Get(id);
        }

        [HttpGet("/difficulty/all")]
        public IList<DifficultyModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost("/difficulty")]
        public DifficultyModel Create(DifficultyLevelDOM difficultyModel)
        {
            return service.Create(difficultyModel);
        }

        [HttpDelete("/difficulty/{id}")]
        public void Delete(long id)
        {
            service.Delete(id);
        }
    }
}
