using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public interface ITeamService
    {
        TeamModel Get(long id);
        IList<TeamModel> GetAll();
        TeamModel Create(TeamColorDOM model);
        void Delete(long id);
    }
}
