using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Json;
using PogoRaids.API.Services;
using PogoRaids.API.DOMModels;
using PogoRaidsBackend.Domain;

namespace PogoRaids.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonService service;

        public PokemonController(IPokemonService service)
        {
            this.service = service;
        }

        [HttpGet("/pokemon/{id}")]
        public PokemonModel GetPokemon(long id)
        {
            return service.Get(id);
        }

        [HttpGet("/pokemon/all")]
        public IList<PokemonModel> GetAll()
        {
            return service.GetAll();
        }

        [HttpPost("/pokemon")]
        public PokemonModel Create(PokemonDOM pokemon)
        {
            return service.Save(pokemon);
        }

        [HttpDelete("/pokemon/{id}")]
        public void Delete(long id)
        {
            service.Delete(id);
        }
    }

}
