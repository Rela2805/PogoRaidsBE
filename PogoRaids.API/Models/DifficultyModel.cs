using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PogoRaidsBackend.Domain;

namespace PogoRaids.API.Models
{
    public class DifficultyModel
    {
        public DifficultyModel(DifficultyDataModel model)
        {
            Id = model.Id;
            Level = model.Level;
        }
        public long Id { get; set; }
        public int Level { get; set; }
    }
}
