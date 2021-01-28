using System;
using System.Collections.Generic;
using System.Text;

namespace PogoRaidsBackend.Domain
{
    public class RaidDataModel
    {
        public virtual long Id { get; protected set; }
        public virtual int MinimalLevel { get; set; }
        public virtual PokemonDataModel Pokemon { get; set; }
        public virtual int StartsIn { get; set; }
        public virtual UserDataModel Creator { get; set; }
        public virtual IList<UserDataModel> Contendors { get; set; }

        public RaidDataModel()
        {
            Contendors = new List<UserDataModel>();
        }
    }
}
