using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.DOMModels
{
    public class RaidDOM
    {
        public int MinimalLevel { get; set; }
        public string PokemonName { get; set; }
        public int StartsIn { get; set; }
        public long CreatorId { get; set; }
    }
}
