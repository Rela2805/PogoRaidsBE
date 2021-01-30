using PogoRaidsBackend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Models
{
    public class RaidModel
    {
        public RaidModel(RaidDataModel model)
        {
            Id = model.Id;
            MinimalLevel = model.MinimalLevel;  
            Pokemon = new PokemonModel(model.Pokemon);
            Creator = new UserModel(model.Creator);
            Contendors = model.Contendors.Select(x => new UserModel(x)).ToList();
        }
        public virtual long Id { get; protected set; }
        public virtual int MinimalLevel { get; set; }
        public virtual PokemonModel Pokemon { get; set; }
        public virtual UserModel Creator { get; set; }
        public virtual IList<UserModel> Contendors { get; set; }
    }
}
