using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PogoRaids.API.DOMModels;

namespace PogoRaids.API.Models
{
    public class UserModel
    {
        public UserModel(long id, string name, string surname, string username, string password, string email, long raidsCompleted, GameUserModel gameUser)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Email = email;
            Password = password;
            RaidsCompleted = raidsCompleted;
            GameUser = gameUser;
        }

        public UserModel(LoginDOM model)
        {
            Id = 1;
            Name = "Marko";
            Surname = "Markic";
            Username = "Unknown";
            Email = model.email;
            Password = model.password;
            RaidsCompleted = 1;
            GameUser = new GameUserModel();
        }

        public UserModel(UserDOM model)
        {
            Id = 0;
            Name = model.Name;
            Surname = model.Surname;
            Username = model.Username;
            Email = model.Email;
            Password = model.Password;
            RaidsCompleted = 0;
            GameUser = new GameUserModel(model.GameNickname, model.GameCode, model.Level, model.Color);
        }

        public UserModel()
        {
            Id = 0;
            Name = "";
            Surname = "";
            Username = "";
            Email = "";
            Password = "";
            RaidsCompleted = 0;
            GameUser = new GameUserModel("", "", 0, "");
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual long RaidsCompleted { get; set; }
        public virtual GameUserModel GameUser { get; set; }

    }
}
