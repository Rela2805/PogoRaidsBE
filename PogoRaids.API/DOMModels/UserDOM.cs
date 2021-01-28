using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.DOMModels
{
    public class UserDOM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GameNickname { get; set; }
        public string GameCode { get; set; }
        public int Level { get; set; }
        public string Color { get; set; }
    }
}
