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
    public class RaidService : IRaidService
    {
        private IRaidRepository raidRepository;
        private IUserRepository userRepository;
        private IPokemonRepository pokemonRepository;
        public RaidService(IRaidRepository raidRepository, IUserRepository userRepository, IPokemonRepository pokemonRepository)
        {
            this.raidRepository = raidRepository;
            this.userRepository = userRepository;
            this.pokemonRepository = pokemonRepository;
        }
        public void AddUserToContenders(long raidId, long userId)
        {
            raidRepository.AddUserToContenders(raidId, userId);
        }

        public void Delete(long raidId, long userId)
        {
            raidRepository.Delete(raidId, userId);
        }

        public RaidModel Get(long id)
        {
            return new RaidModel(raidRepository.Get(id));
        }

        public IList<RaidModel> GetAll()
        {
            return raidRepository.GetAll().Select(x => new RaidModel(x)).ToList();
        }

        public void RemoveUserFromContenders(long raidId, long userId)
        {
            raidRepository.RemoveUserFromContenders(raidId, userId);
        }

        public RaidModel Save(RaidDOM raidModel)
        {
            var pokemon = pokemonRepository.GetByName(raidModel.PokemonName);
            var creator = userRepository.Get(raidModel.CreatorId);
            var raid = new RaidDataModel { MinimalLevel = raidModel.MinimalLevel, Pokemon = pokemon, Creator = creator, StartsIn = raidModel.StartsIn };
            creator.CreatedRaids.Add(raid);
            pokemon.Raids.Add(raid);

            return new RaidModel(raidRepository.Save(raid));
        }
    }
}
