using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PogoRaidsBackend.Domain
{
    public class DifficultyDataModel
    {
        public virtual long Id { get; protected set; }
        public virtual int Level { get; set; }
        public virtual IList<PokemonDataModel> Pokemons { get; set; }
        public DifficultyDataModel()
        {
            Pokemons = new List<PokemonDataModel>();
        }
}
}
