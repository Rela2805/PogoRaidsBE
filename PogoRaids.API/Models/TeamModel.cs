using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Models
{
    public class TeamModel
    {
        public TeamModel(TeamDataModel model)
        {
            Id = model.Id;
            Color = model.Color;
        }
        public long Id { get; set; }
        public string Color { get; set; }
    }
}
