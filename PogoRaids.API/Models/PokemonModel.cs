using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PogoRaidsBackend.Domain;

namespace PogoRaids.API.Models
{
    public class PokemonModel
    {
        public PokemonModel(PokemonDataModel model)
        {
            Id = model.Id;
            Name = model.Name;
            ImageId = model.ImageId;
            Difficulty = new DifficultyModel(model.Difficulty);
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }
        public DifficultyModel Difficulty { get; set; }
    }
}
