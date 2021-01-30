using PogoRaids.API.DOMModels;
using PogoRaids.API.Models;
using PogoRaidsBackend.Domain;
using PogoRaidsBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoRaids.API.Services
{
    public class TeamService : ITeamService
    {
        private ITeamRepository repository;

        public TeamService(ITeamRepository repository)
        {
            this.repository = repository;
        }
        public TeamModel Create(TeamColorDOM model)
        {
            var team = new TeamDataModel() { Color = model.Color };
            return new TeamModel(repository.Save(team));
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

        public TeamModel Get(long id)
        {
            return new TeamModel(repository.Get(id));
        }

        public IList<TeamModel> GetAll()
        {
            return repository.GetAll().Select(x => new TeamModel(x)).ToList();
        }
    }
}
