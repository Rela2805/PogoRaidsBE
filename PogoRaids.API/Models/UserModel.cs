using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PogoRaids.API.DOMModels;
using PogoRaidsBackend.Domain;

namespace PogoRaids.API.Models
{
    public class UserModel
    {
        public UserModel(UserDataModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Surname = model.Surname;
            Username = model.Username;
            Email = model.Email;
            RaidsCompleted = model.RaidsCompleted;
            GameNickname = model.GameNickname;
            GameCode = model.GameCode;
            Level = model.Level;
            Team = new TeamModel(model.Team);
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long RaidsCompleted { get; set; }
        public string GameNickname { get; set; }
        public string GameCode { get; set; }
        public int Level { get; set; }
        public TeamModel Team { get; set; }

    }
}
