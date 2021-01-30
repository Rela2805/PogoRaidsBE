using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaids.API.Services;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PogoRaidsBackend.Services
{
    public class PokemonService : IPokemonService
    {
        private IPokemonRepository pokemonRepository;
        private IDifficultyRepository difficultyRepository;

        public PokemonService(IPokemonRepository pokemonRepository, IDifficultyRepository difficultyRepository)
        {
            this.pokemonRepository = pokemonRepository;
            this.difficultyRepository = difficultyRepository;
        }

        public PokemonModel Save(PokemonDOM pokemonModel)
        {
            var difficulty = difficultyRepository.GetByLevel(pokemonModel.DifficultyLevel);
            var pokemon = new PokemonDataModel { Name = pokemonModel.Name, ImageId = pokemonModel.ImageId, Difficulty = difficulty };
            difficulty.Pokemons.Add(pokemon);

            return new PokemonModel(pokemonRepository.Save(pokemon));
        }

        public IList<PokemonModel> GetAll()
        {
            return pokemonRepository.GetAll().Select(x => new PokemonModel(x)).ToList();
        }

        public PokemonModel Get(long id)
        {
            return new PokemonModel(pokemonRepository.Get(id));
        }

        public void Delete(long id)
        {
            pokemonRepository.Delete(id);
        }
    }
}
