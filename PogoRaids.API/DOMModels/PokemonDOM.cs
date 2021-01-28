using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.DOMModels
{
    public class PokemonDOM
    {
        public virtual string Name { get; set; }
        public virtual string ImageId { get; set; }
        public virtual int DifficultyLevel { get; set; }
    }
}
