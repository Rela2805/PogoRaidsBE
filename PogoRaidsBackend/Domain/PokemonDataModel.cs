using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PogoRaidsBackend.Domain
{
    public class PokemonDataModel
    {
        public virtual long Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string ImageId { get; set; }
        public virtual DifficultyDataModel Difficulty { get; set; }
        public virtual IList<RaidDataModel> Raids { get; set; }

        public PokemonDataModel()
        {
            Raids = new List<RaidDataModel>();
        }
    }
}
