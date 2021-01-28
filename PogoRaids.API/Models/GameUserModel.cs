using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Models
{
    public class GameUserModel
    {
        public GameUserModel(string nickname, string gameCode, int level, string color)
        {
            Id = 0;
            Nickname = nickname;
            GameCode = gameCode;
            Level = level;
            Team = new TeamModel(color);
        }

        public GameUserModel()
        {
            Id = 0;
            Nickname = "";
            GameCode = "";
            Level = 30;
            Team = new TeamModel();
        }

        public virtual long Id { get; set; }
        public virtual string Nickname { get; set; }
        public virtual string GameCode { get; set; }
        public virtual int Level { get; set; }
        public virtual TeamModel Team { get; set; }
    }
}
