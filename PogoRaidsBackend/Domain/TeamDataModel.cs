using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PogoRaidsBackend.Domain
{
    public class TeamDataModel
    {
        public virtual long Id { get; protected set; }
        public virtual string Color { get; set; }
        public virtual IList<UserDataModel> Members { get; set; }
        
        public TeamDataModel()
        {
            Members = new List<UserDataModel>();
        }
    }
}
