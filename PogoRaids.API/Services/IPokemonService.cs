using PogoRaids.API.DOMModels;
using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface IPokemonService
    {
        PokemonDataModel Save(PokemonDOM pokemonModel);
        IList<PokemonDataModel> GetAll();
        PokemonDataModel Get(long id);
        void Delete(long id);
    }
}
