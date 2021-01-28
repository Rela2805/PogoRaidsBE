using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Models
{
    public class TeamModel
    {
        public TeamModel(string color)
        {
            Id = 0;
            Color = color;
        }
        public TeamModel()
        {
            Id = 0;
            Color = "blue";
        }

        public virtual long Id { get; set; }
        public virtual string Color { get; set; }
    }
}
