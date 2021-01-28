using PogoRaids.API.DOMModels;
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
        public RaidDataModel AddUserToContenders(long raidId, long userId)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public RaidDataModel Get(long id)
        {
            return raidRepository.Get(id);
        }

        public IList<RaidDataModel> GetAll()
        {
            return raidRepository.GetAll();
        }

        public RaidDataModel RemoveUserFromContenders(long raidId, long userId)
        {
            throw new NotImplementedException();
        }

        public RaidDataModel Save(RaidDOM raidModel)
        {
            var pokemon = pokemonRepository.GetByName(raidModel.PokemonName);
            var creator = userRepository.Get(raidModel.CreatorId);
            var raid = new RaidDataModel { MinimalLevel = raidModel.MinimalLevel, Pokemon = pokemon, Creator = creator, StartsIn = raidModel.StartsIn };
            creator.CreatedRaids.Add(raid);
            pokemon.Raids.Add(raid);

            return raidRepository.Save(raid);
        }
    }
}
