using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("/user/login")]
        public UserModel Login(LoginDOM loginInfo)
        {
            return new UserModel(loginInfo);
        }

        [HttpPost("/user/register")]
        public UserModel Register(UserDOM registerInfo)
        {
            return new UserModel(registerInfo);
        }
    }
}
