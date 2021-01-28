using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PogoRaids.API.Models
{
    public class PokemonModel
    {
        public PokemonModel()
        {
            this.Id = 10;
            this.Name = "None";
            this.ImageId = "None";
            this.Difficulty = new DifficultyModel();
        }

        public PokemonModel(long id, string name, string imageId, DifficultyModel difficulty)
        {
            Id = id;
            Name = name;
            ImageId = imageId;
            Difficulty = difficulty;
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("imageId")]
        public string ImageId { get; set; }
        [JsonProperty("difficulty")]
        public DifficultyModel Difficulty { get; set; }
    }
}
