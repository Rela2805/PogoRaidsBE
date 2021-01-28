using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Repository
{
    public interface IPokemonRepository
    {
        PokemonDataModel Save(PokemonDataModel pokemonModel);
        IList<PokemonDataModel> GetAll();
        void Delete(long id);
        PokemonDataModel Get(long id);
        PokemonDataModel GetByName(string name);
    }
}
