using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PogoRaids.API.Models
{
    public class DifficultyModel
    {
        public DifficultyModel()
        {
            this.Id = 1;
            this.Level = 1;
        }

        public DifficultyModel(long id, int level)
        {
            Id = id;
            Level = level;
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
    }
}
