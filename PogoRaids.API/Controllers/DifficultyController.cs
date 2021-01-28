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
    public class DifficultyController : ControllerBase
    {
        private IDifficultyRepository repository;

        public DifficultyController(IDifficultyRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("/difficulty/{id}")]
        public DifficultyDataModel GetTeam(long id)
        {
            return repository.Get(id);
        }

        [HttpGet("/difficulty/all")]
        public IList<DifficultyDataModel> GetAll()
        {
            return repository.GetAll();
        }

        [HttpPost("/difficulty")]
        public DifficultyDataModel Create(DifficultyLevelDOM difficultyModel)
        {
            var difficulty = new DifficultyDataModel() { Level = difficultyModel.Level };
            return repository.Save(difficulty);
        }

        [HttpDelete("/difficulty/{id}")]
        public void Delete(long id)
        {
            repository.Delete(id);
        }
    }
}
