using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaids.API.Services;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService Service;
        public UserController(IUserService Service)
        {
            this.Service = Service;
        }
        [HttpGet("/user/all")]
        public IList<UserModel> GetAll()
        {
            return Service.GetAll();
        }

        [HttpGet("/user/{id}")]
        public UserModel GetUser(long id)
        {
            return Service.Get(id);
        }

        [HttpPost("/user/register")]
        public UserModel Create(UserDOM model)
        {
            return Service.Create(model);
        }
        [HttpGet("/user/login")]
        public UserModel LogIn(string password, string email)
        {
            return Service.Login(password, email);
        }
        [HttpDelete("/user/{id}")]
        public void Delete(long id)
        {
            Service.Delete(id);
        }

        [HttpPatch("/user/{id}")]
        public void Update(long id, [FromBody] UserDOM model)
        {
            Service.Update(id, model);
        }
        [HttpGet("/user/active")]
        public IList<UserModel> GetMostActive()
        {
            return Service.GetMostActive();
        }
    }
}
