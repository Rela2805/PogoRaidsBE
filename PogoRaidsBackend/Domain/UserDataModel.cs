using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PogoRaidsBackend.Domain
{
    public class UserDataModel
    {
        public virtual long Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual long RaidsCompleted { get; set; }
        public virtual string GameNickname { get; set; }
        public virtual string GameCode { get; set; }
        public virtual int Level { get; set; }
        public virtual TeamDataModel Team { get; set; }
        public virtual IList<RaidDataModel> CreatedRaids { get; set; }
        public virtual IList<RaidDataModel> ParticipatedRaids { get; set; }

        public UserDataModel()
        {
            CreatedRaids = new List<RaidDataModel>();
            ParticipatedRaids = new List<RaidDataModel>();
        }
    }
}
