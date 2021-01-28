using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Models
{
    public class RaidModel
    {
        public RaidModel(long id, int minimalLevel, long pokemonId, DateTime startTime, UserModel user)
        {
            Id = id;
            MinimalLevel = minimalLevel;
            PokemonId = pokemonId;
            StartTime = startTime;
            User = user;
        }

        public virtual long Id { get; set; }
        public virtual int MinimalLevel { get; set; }
        public virtual long PokemonId { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual UserModel User { get; set; }
    }
}
